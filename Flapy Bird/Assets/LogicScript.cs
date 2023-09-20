using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    

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


}
