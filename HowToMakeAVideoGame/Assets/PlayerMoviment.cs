
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    

    // Update is called once per frame

    //  {[* Time.delta *]}, faz com que a taxa de atualizacao seja adequada

    void Update()
    {
        rb.AddForce (0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce *  Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }

    }
}
