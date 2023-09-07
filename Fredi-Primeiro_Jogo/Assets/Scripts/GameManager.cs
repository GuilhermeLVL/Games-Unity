using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject hazardPrefab;

    public int maxHazardsToSpawn = 4;

    public TMPro.TextMeshProUGUI scoreText;


    private int score;
    private float timer;
    private static bool gameOver;

  

    void Start()
    {

       // StartCoroutine(SpawnHazards());
        InvokeRepeating("SpawnHazards", 0,1f);
    }



    private void Update()
    {
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

    private void SpawnHazards()
    {
        var hazardToSpawn = Random.Range(1,maxHazardsToSpawn);

        for (int i = 0; i < hazardToSpawn; i++)
        {

            var x = Random.Range(-7, 7);
            var drag = Random.Range(0f, 2f);

            var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, 0), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().drag = drag;
        }

       

        //yield return new WaitForSeconds (1f);

        //yield return SpawnHazards();
    }

    public static void GameOver()
    {
        gameOver = true;
    }
}
