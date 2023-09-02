using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using System.Xml.Serialization;

public class NewBehaviourScript : MonoBehaviour
{
    
    public int score;

    public TextMeshProUGUI scoreDisplay;

    private void Update()
    {
        scoreDisplay.text = score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    { 

      if(other.CompareTag("Obstacle"))
        {
            score++;
            

        }
    }
}
