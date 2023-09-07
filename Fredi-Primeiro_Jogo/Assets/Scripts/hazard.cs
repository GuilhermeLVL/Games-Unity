using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard : MonoBehaviour
{
    Vector3 rotation;

    private void Start()
    {
        rotation = new Vector3(1,0);
    }

    private void Update()
    {
        transform.Rotate(rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
