using System.Collections;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your Enemy Prefab in Inspector
    public int enemyCount; // Number of enemies to spawn
    public float spawnDelay; // Delay between each spawn
    public float initialSpawnDelay; // Initial delay before starting to spawn

    void Start()
    {
        StartCoroutine(InitialDelay());
    }

    IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(initialSpawnDelay);
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
