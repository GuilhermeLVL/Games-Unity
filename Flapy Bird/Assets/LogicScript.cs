using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bibliotrcas importadas
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    

    //Cria um botao para acessar a funcao pela propria unity
    [ContextMenu("Increase Score")]

    //Funcao que acrecenta Ponto para o jogador
    //Sempre que essa funcao for chamda
    //ela vai somar mais 1 a variavel "PlayerScore"
    //Depois ela ira converter essa valor para string
    //E passar esse valor para o texto (scoreText).
    public void addScore()
    {
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString() ;
       
    }

    //Permite que o jogo possa ser reiniciado apos o GameOver
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
