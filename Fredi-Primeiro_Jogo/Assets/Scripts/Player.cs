using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;
    public ParticleSystem deathParticles;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }
    }
}
