using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerp : MonoBehaviour
{
    public float A;
    public float B;
    public float t;

    public float LerpValue;


    // Update is called once per frame
    void Update()
    {
     
    LerpValue = Mathf.Lerp(A, B, t);
    }
}
