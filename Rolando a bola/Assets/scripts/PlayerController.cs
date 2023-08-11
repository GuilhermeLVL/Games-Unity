using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    //Criacao de variavel.

    //velocidade de movimento
    public float speed = 1;

    private Rigidbody rb;
    private float movementX;
    private float movementY;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f ,movementY);
        rb.AddForce(movement * speed);
    }

    //Funcao sem retorno, apenas executa uma tarefa
     void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
