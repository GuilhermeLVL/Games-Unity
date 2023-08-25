using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour { 
        
    
    public float Yincrement;

    private Vector2 targetPos;

    public float speed;


    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;

        } else if (Input.GetKeyDown(KeyCode.DownArrow))
    {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
        }
    }
}
