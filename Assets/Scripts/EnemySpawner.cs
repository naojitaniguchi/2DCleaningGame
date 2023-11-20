using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int enemyMax = 10 ;
    [SerializeField] float spawnTime = 0.5f;
    [SerializeField] GameObject enemyPrefab;
    int spawnCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while ( spawnCount < enemyMax)
        {
            yield return new WaitForSeconds(spawnTime);

            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;
            enemy.transform.rotation = Quaternion.identity;
            spawnCount++;

        }
    }
}
