using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{

    public int maxEnemies = 20, currentEnemies = 0, wave = 1;
    public float spawnRadius = 7f, time = 1.5f;
    public GameObject spawner;
    public GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        SpawnAnEnemy();
    }

    private IEnumerator SpawnAnEnemy()
    {
        Debug.Log("2");
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        Debug.Log("3");
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Debug.Log("Enemy Spawning");
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
