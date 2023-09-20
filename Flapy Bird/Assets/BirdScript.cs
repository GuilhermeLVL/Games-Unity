using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D MyRigidBody;
    public float FlapStrength;
    public bool birdIsAlive = true;
    public LogicScript Logic;


    public Transform Player;
    public float posLimit = 20;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {

            MyRigidBody.velocity = Vector2.up * FlapStrength;
        
        }

        if (Player.position.y >= 20 || Player.position.y <= -20)
        {
            GameOver();
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    void GameOver()
    {
        Logic.gameOver();
        birdIsAlive = false;
    }

}
