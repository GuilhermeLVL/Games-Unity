
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;

    

    // Update is called once per frame

    //  {[* Time.delta *]}, faz com que a taxa de atualizacao seja adequada

    void Update()
    {
        rb.AddForce (0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(500 *  Time.deltaTime, 0, 0);
        }

    }
}
