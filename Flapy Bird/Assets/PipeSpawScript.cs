using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawRate = 2;
    private float timer = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

   
     if (timer <= spawRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {

            //Spaw do Pipe na posicao e rotacao padrao do Prefab
            Instantiate(pipe, transform.position, transform.rotation);

            timer = 0;
        }
        
    }
}
