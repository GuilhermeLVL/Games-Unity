using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void SpawnWave()
    {
        //Quanto maior for o level + Vezes a funcao SpawnEnemy() sera chamada
        //Gerando a cada lvl uma quantidade maior de inimigos

        for (int i = 0; i < waveNumber; i++) 
        {
            SpawnEnemy();
        }

        //Acrescenta +1 ao numero da partida
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position, spawnPoint.rotation);
    }
}
