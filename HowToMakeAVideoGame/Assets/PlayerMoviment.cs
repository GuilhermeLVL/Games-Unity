
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public Rigidbody rb;
    


    

    // Update is called once per frame

    //Time.delta, faz com que a taxa de atualizacao seja adequada

    void Update()
    {
        rb.AddForce (0, 0, 2000 * Time.deltaTime);
    }
}
