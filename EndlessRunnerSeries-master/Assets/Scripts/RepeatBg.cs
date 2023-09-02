using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBg : MonoBehaviour
{

    public float speed;

    public float endX;
    public float StartX;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= endX) { 
        
        Vector2 pos = new Vector2(StartX, transform.position.y);
            transform.position = pos;
        }
    }

}
