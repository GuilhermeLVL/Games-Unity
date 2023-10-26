using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
 
 //serializeField permite que a variavel "PRIVADA" possa ser acessada pela unity sem ser publica,
 // assim, o campo que receber esse script pode alterar o valor da variavel e ela permanece privada para os demais campos.
 
 [SerializeField]private Rigidbody2D oRigidBody2D;


[SerializeField] private LineRenderer oLineRenderer;

   private void Start()
    {
    
     
    }

   
    private void Update()
    {
        
    }
}
