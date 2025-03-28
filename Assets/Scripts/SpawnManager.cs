using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnpoint;
    public GameObject EnemyPrefab;
    public GameObject EnemyPrefabRed;

    public Wave[] waves;
    public int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Spawn()
    {
        int ballon = Random.Range(0, spawnpoint.Length);
        Instantiate(EnemyPrefab, spawnpoint[ballon].position, Quaternion.identity);
        int ballonRed = Random.Range(0, spawnpoint.Length);
        Instantiate(EnemyPrefabRed, spawnpoint[ballonRed].position, Quaternion.identity);
    }

    IEnumerator SpawnRoutine()
    {
        while(currentWave < waves.Length)
        {
            Debug.Log($"Wave: {currentWave + 1}");
            Wave wave = waves[currentWave];
            yield return new WaitForSeconds(wave.Delaystart);

            for (int i = 0; i < wave.totalSpawnEnemies; i++)
            {
                int EnemyIndex = Random.Range(0, wave.numberOfRandomSpawn);
                Instantiate(EnemyPrefab, spawnpoint[EnemyIndex].position, Quaternion.identity);
                yield return new WaitForSeconds(wave.spawnInterval);
            }
            for (int i = 0; i < wave.totalSpawnEnemies; i++)
            {
                int EnemyIndexRed = Random.Range(0, wave.numberOfRandomSpawn);
                Instantiate(EnemyPrefabRed, spawnpoint[EnemyIndexRed].position, Quaternion.identity);
                yield return new WaitForSeconds(wave.spawnInterval);
            }

            Debug.Log("Next Wave");
            currentWave++;
        }
        Debug.Log("Finished!!");
    }
}
