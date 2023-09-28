
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    //TEMPO ENTRE AS WAVES
    public float timeBetweenWaves = 5f;

    //Tempo para o Spawn Das Waves
    private float countdown = 2f;

    public Text WaveCount;

    //Numero da rodada
    private int waveNumber = 0;

    private void Update()
    {

        

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        //Passa o valor para string, limita as casas decimais e passa o valor para var waveCount
        WaveCount.text = Mathf.Round(countdown).ToString();
    }

    //Ienumerator e uma ko-rotina um trecho de codigo que e executado em outro tempo

    IEnumerator SpawnWave()
    {

        //Acrescenta +1 ao numero da partida
        waveNumber++;

        


        //Quanto maior for o level + Vezes a funcao SpawnEnemy() sera chamada
        //Gerando a cada lvl uma quantidade maior de inimigos

        for (int i = 0; i < waveNumber; i++) 
        {
            SpawnEnemy();

            //Definindo um tempo de espera
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position, spawnPoint.rotation);
    }
}
