using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class hazard : MonoBehaviour
{
    Vector3 rotation;

    public ParticleSystem breakingEffect;
    private CinemachineImpulseSource CinemachineImpulseSource;

    private void Start()
    {
        CinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        var xRotation = Random.Range(0.5f,1f);
        rotation = new Vector3(-xRotation,0);
    }

    private void Update()
    {
        transform.Rotate(rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("hazard"))
        Destroy(gameObject);
        Instantiate(breakingEffect, transform.position, Quaternion.identity);

        CinemachineImpulseSource.GenerateImpulse();
    }
}
