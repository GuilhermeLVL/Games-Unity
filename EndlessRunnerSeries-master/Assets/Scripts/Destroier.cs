using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Destroier : MonoBehaviour
{
    public float lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }   
}
