using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;
    public int newEnemyType;
    private void Awake()
    {
        for (int i = 0; i < numberOfEnemies; i++){
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-35, 40), Random.Range(-35, 40), 0), Quaternion.identity);
            newEnemy.GetComponent<Enemy>().enemyType = newEnemyType;
        }
    }
}
