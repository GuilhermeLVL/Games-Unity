
using UnityEngine;


public class PlayerColision : MonoBehaviour
{
    public PlayerMoviment moviment;
    

    private void OnCollisionEnter(Collision collisionInfo)
    {
      if (collisionInfo.collider.tag == "Obstaculo") 
        {
            moviment.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
