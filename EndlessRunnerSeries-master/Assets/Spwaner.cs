using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{

    public GameObject obstacle;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreseTime;
    public float minTime = 0.65f;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;

            if(startTimeBtwSpawn >= minTime)
            {
                startTimeBtwSpawn -= decreseTime;
            }
            
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
