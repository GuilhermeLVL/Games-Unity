using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameManager gameManager;
    public void Play()
    {
        gameManager.Enabled();
        Destroy(gameObject);
    }

}
