using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
 
 //serializeField permite que a variavel "PRIVADA" possa ser acessada pela unity sem ser publica,
 // assim, o campo que receber esse script pode alterar o valor da variavel e ela permanece privada para os demais campos.
 
 [SerializeField]private Rigidbody2D oRigidBody2D;


[SerializeField] private LineRenderer oLineRenderer;

[SerializeField] private Camera cameraDoJogo;


    [SerializeField] private float forcaParaAdicionar;
    [SerializeField] private float limiteDoArrastar;


    private Vector3 posicaoDoMouse;
    private bool estaArrastando;

   private void Start()
    {
        oLineRenderer.positionCount = 2;
        oLineRenderer.SetPosition(0,Vector2.zero);
        oLineRenderer.SetPosition(1, Vector2.zero);
        oLineRenderer.enabled = false;


    }

   
    private void Update()
    {
        pegarPosicaoDoMouse();

        //GetMouseButtonDown Verifica se o mouse esta sendo apertado
        if (Input.GetMouseButtonDown(0) && estaArrastando == false) 
        {
            IniciarArrastar();
        }

        if (estaArrastando)
        {
            Arrastar();
        }

        //GetMouseButtonUp Verifica se o mouse parou de ser apertado
        if (Input.GetMouseButtonUp(0) && estaArrastando)
        {
            pararDeArrastar();
        }
    }

    private void pegarPosicaoDoMouse()
    {
        posicaoDoMouse = cameraDoJogo.ScreenToWorldPoint(Input.mousePosition);
        posicaoDoMouse.z = 0f;

    }

    private void IniciarArrastar()
    {
        estaArrastando = true;

        oLineRenderer.enabled = true;
        oLineRenderer.SetPosition(0, posicaoDoMouse);
        oLineRenderer.SetPosition(1,Vector2.zero);
    }

    private void Arrastar()
    {
        Vector3 posicaoInicial = oLineRenderer.GetPosition(0);
        Vector3 posicaoAtual = posicaoDoMouse;

        oLineRenderer.SetPosition(1, posicaoAtual);

    }

    private void pararDeArrastar()
    {
        estaArrastando = false;
        oLineRenderer.enabled = false;
    }

}
