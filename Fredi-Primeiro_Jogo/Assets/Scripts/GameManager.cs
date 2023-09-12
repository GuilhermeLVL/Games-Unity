using System;
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

        if(Input.GetKeyDown(KeyCode.Escape))
        { 
        Time.timeScale = 0;
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

    IEnumerable ScaleTime (float start, float end, float duration)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;
        while(timer < duration) 
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / duration);
            Time.fixedDeltaTime = 0.2f * Time.timeScale;
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }
        Time.timeScale = end;
        Time.fixedDeltaTime =0.02f * Time.timeScale;
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
