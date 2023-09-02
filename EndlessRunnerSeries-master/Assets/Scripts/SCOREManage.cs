using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    
    public int score;
    private void OnTriggerEnter2D(Collider2D other)
    { 

      if(other.CompareTag("Obstacle"))
        {
            score++;
            

        }
    }
}
