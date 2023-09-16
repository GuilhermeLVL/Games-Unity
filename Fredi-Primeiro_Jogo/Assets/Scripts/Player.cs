using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float forceMultiplier = 3f;
    [SerializeField]
    private float maximumVelocity = 3f;
    [SerializeField]
    private ParticleSystem deathParticles;

    private Rigidbody rb;

    //Importacao das cameras 
    private CinemachineImpulseSource CinemachineImpulseSource;
  

    // Start is called before the first frame update


   

    void Awake()
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

        float horizontalInput = 0;

        if (Input.GetMouseButton(0))
        {
            var center = Screen.width / 2;
            var mouseposition = Input.mousePosition;

            if (mouseposition.x > center)
            {
                horizontalInput = 1;
            }
            else if (mouseposition.x < center)
            {
                horizontalInput = -1;
            }
        }
        else 
        { 
         var HorizontalInput = Input.GetAxis("Horizontal");
        }
       
        if (rb.velocity.magnitude <= maximumVelocity )
        {
            rb.AddForce(new Vector3(horizontalInput * forceMultiplier * Time.deltaTime,0,0));

        }


    }

    private void OnEnable()
    {
        transform.position = new Vector3(0, 0.75f, 0);
        rb.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hazard"))
        {
            GameOver();
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

            //Tremor
            CinemachineImpulseSource.GenerateImpulse();

            //Desabilitando a camera que segue e habilitando a camera de morte/zom
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("falldown"))
        {
            GameOver();
        }
    }

    

    private void GameOver()
    {
        GameManager.Instance.GameOver();
        gameObject.SetActive(false);
    }
}
