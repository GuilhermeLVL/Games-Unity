using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var HorizontalInput = Input.GetAxis("Horizontal");
        if (GetComponent<Rigidbody>().velocity.magnitude <= maximumVelocity )
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(HorizontalInput * forceMultiplier,0,0));

        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hazard"))
        {

            Destroy(gameObject);  
        }
    }
}
