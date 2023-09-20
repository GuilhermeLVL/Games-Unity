using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawRate = 2;
    private float timer = 0;
    public float heightOffset = 10;

    void Start()
    {
        SpawPoint();
    }
    

    void Update()
    {

        //  **No primeiro frame**

        // Timer comeca sendo menor que spawRate, Caindo no (if)
        // mas passsa a ter o valor da taxa de atualizacao, Caindo no (Else)
        if (timer <= spawRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {

            SpawPoint();

            timer = 0;
        }
        
    }

    void SpawPoint()
    {

        float lowestPoint = transform.position.y - heightOffset;

        float highestPoint = transform.position.y + heightOffset;
        //Spaw do Pipe na posicao e rotacao padrao do Prefab
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation) ;
    }
}
