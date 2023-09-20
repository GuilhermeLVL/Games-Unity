using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
//Gambiarra para ter acionar o metodo  addScore() do Script LogicScript
//Esse metodo e responsavel pelos pontos do jogador;

    public LogicScript logic;
    


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.addScore();
    }
}
