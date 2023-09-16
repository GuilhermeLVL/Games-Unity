using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    public GameObject hazardPrefab;

    public int maxHazardsToSpawn = 4;

    public TMPro.TextMeshProUGUI scoreText;

    public GameObject player;

    public Image backGroundMenu;

    public GameObject mainVcam;
    public GameObject zoomVcam;

    public GameObject gameOverMenu;

    private int score;
    private float timer;
    private bool gameOver;
    private Coroutine hazardsCoroutine;


  

    private static GameManager instance;
    public static GameManager Instance => instance;
    void Start()
    {
        instance = this;

       
        
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
                LeanTween.value(0, 1, 0.75f).setOnUpdate(SetTimeScale).setIgnoreTimeScale(true);
                //StartCoroutine(ScaleTime(0, 1, 0.5f));
                backGroundMenu.gameObject.SetActive(false);
            }
            if (Time.timeScale == 1)
            {
                LeanTween.value(1, 0, 0.75f).setOnUpdate(SetTimeScale).setIgnoreTimeScale(true);
                //StartCoroutine(ScaleTime(1, 0, 0.5f));
                backGroundMenu.gameObject.SetActive(true);
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
            LeanTween.value(Time.timeScale, 1, 0.75f).setOnUpdate(SetTimeScale).setIgnoreTimeScale(true);
            //StartCoroutine(ScaleTime(0, 1, 0.5f));
            backGroundMenu.gameObject.SetActive(false);
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
