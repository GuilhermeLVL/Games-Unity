using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;
    public ParticleSystem deathParticles;

    private Rigidbody rb;

    //Importacao das cameras 
    private CinemachineImpulseSource CinemachineImpulseSource;
  

    // Start is called before the first frame update


   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance == null)
        {
            return;
        }

        var HorizontalInput = Input.GetAxis("Horizontal");
        if (rb.velocity.magnitude <= maximumVelocity )
        {
            rb.AddForce(new Vector3(HorizontalInput * forceMultiplier * Time.deltaTime,0,0));
           

        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hazard"))
        {
            GameManager.Instance.GameOver();
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

            //Tremor
            CinemachineImpulseSource.GenerateImpulse();

            //Desabilitando a camera que segue e habilitando a camera de morte/zom
           
        }
    }
}
