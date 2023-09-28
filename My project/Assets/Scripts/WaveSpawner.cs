
using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    //Tempo para o Spawn Das Waves
    private float countdown = 2f;

    //Numero da rodada
    private int waveNumber = 1;

    private void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    //Ienumerator e uma ko-rotina um trecho de codigo que e executado em outro tempo

    IEnumerator SpawnWave()
    {
        //Quanto maior for o level + Vezes a funcao SpawnEnemy() sera chamada
        //Gerando a cada lvl uma quantidade maior de inimigos

        for (int i = 0; i < waveNumber; i++) 
        {
            SpawnEnemy();

            //Definindo um tempo de espera
            yield return new WaitForSeconds(0.5f);
        }

        //Acrescenta +1 ao numero da partida
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position, spawnPoint.rotation);
    }
}
