using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour { 
        
    
    public float Yincrement;

    private Vector2 targetPos;

    public float speed;

    public float maxHeight;
    public float minHeight;

    public int health = 6;

    public GameObject effect;

    void Update()
    {

        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Move o player para o centro da tela com a velocidade da variavel speed
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //Funcao que pega as teclas digitadas e (cima e baixo)
        // para deslocar o player no eixo Y
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;

        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
    {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
        }


    }
}
