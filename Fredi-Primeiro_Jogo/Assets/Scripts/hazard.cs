using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class hazard : MonoBehaviour
{
    Vector3 rotation;

    public ParticleSystem breakingEffect;
    private CinemachineImpulseSource CinemachineImpulseSource;
    private Player Player;

    private void Start()
    {
        CinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();

        //Pega a posicao do player (Vibracao da tela)
        Player = FindObjectOfType<Player>();

        var xRotation = Random.Range(90f,180f);
        rotation = new Vector3(-xRotation,0);
    }

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("hazard"))
        Destroy(gameObject);
        Instantiate(breakingEffect, transform.position, Quaternion.identity);

        //Armazena a posicao do player (Vibracao da tela)
        if(Player != null)
        {
                var distance = Vector3.Distance(transform.position, Player.transform.position);
       
                var force = 1 / distance;

                CinemachineImpulseSource.GenerateImpulse(force);
        }
       
    }
}
