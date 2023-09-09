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
    public CinemachineVirtualCamera mainVCam;
    public CinemachineVirtualCamera zommVcam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var HorizontalInput = Input.GetAxis("Horizontal");
        if (rb.velocity.magnitude <= maximumVelocity )
        {
            rb.AddForce(new Vector3(HorizontalInput * forceMultiplier,0,0));

        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hazard"))
        {
            GameManager.GameOver();
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);

            //Tremor
            CinemachineImpulseSource.GenerateImpulse();

            //Desabilitando a camera que segue e habilitando a camera de morte/zom
            mainVCam.gameObject.SetActive(false);
            zommVcam.gameObject.SetActive(true);
        }
    }
}
