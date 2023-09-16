using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject hazardPrefab;
    [SerializeField]
    private int maxHazardsToSpawn = 4;
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Image backGroundMenu;
    [SerializeField]
    private GameObject mainVcam;
    [SerializeField]
    private GameObject zoomVcam;
    [SerializeField]
    private GameObject gameOverMenu;


    private int highScore;
    private int score;
    private float timer;
    private bool gameOver;
    private Coroutine hazardsCoroutine;


  

    private static GameManager instance;
    private const string HighScorePrefeceKey = "HighScore";

    public static GameManager Instance => instance;

    public int HighScore => highScore;
    void Start()
    {
        instance = this;
        highScore = PlayerPrefs.GetInt(HighScorePrefeceKey);

       
        
    }

    private void OnEnable()
    {

        player.SetActive(true);
        mainVcam.SetActive(true);
        zoomVcam.SetActive(false);

        gameOver = false;
        scoreText.text = "0";
        score = 0;
        timer = 0;

        hazardsCoroutine = StartCoroutine(SpawnHazards());
    }



    private void Update()
    {

      if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                UnPause();
            }
            if (Time.timeScale == 1)
            {
                Pause();
            }
        }


        if (gameOver)
            return;

        timer += Time.deltaTime;

        if(timer > 1f)
        {
            score++;
            scoreText.text = score.ToString();

            timer = 0;
        }
    }

    private void Pause()
    {
        LeanTween.value(1, 0, 0.75f).setOnUpdate(SetTimeScale).setIgnoreTimeScale(true);
        //StartCoroutine(ScaleTime(1, 0, 0.5f));
        backGroundMenu.gameObject.SetActive(true);
    }

    private void UnPause()
    {
        LeanTween.value(0, 1, 0.75f).setOnUpdate(SetTimeScale).setIgnoreTimeScale(true);
        //StartCoroutine(ScaleTime(0, 1, 0.5f));
        backGroundMenu.gameObject.SetActive(false);
    }

    private void SetTimeScale(float value)
    {
        Time.timeScale = value;
        Time.fixedDeltaTime = 0.02f * value;
    }

   

    private IEnumerator SpawnHazards()
    {
        var hazardToSpawn = Random.Range(1,maxHazardsToSpawn);

        for (int i = 0; i < hazardToSpawn; i++)
        {

            var x = Random.Range(-7, 7);
            var drag = Random.Range(0f, 2f);

            var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, 0), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().drag = drag;
        }

        var timeToWait = Random.Range(0.5f, 1.5f);

        yield return new WaitForSeconds (timeToWait);

        yield return SpawnHazards();
    }

    public void GameOver()
    {

        StopCoroutine(hazardsCoroutine);
        gameOver = true;

        if (Time.timeScale < 1)
        {
            UnPause();
        }

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScorePrefeceKey, highScore);

        }

        mainVcam.SetActive(false);
        zoomVcam.SetActive(true);

        gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void Enabled()
    {
        gameObject.SetActive(true);
    }

}
