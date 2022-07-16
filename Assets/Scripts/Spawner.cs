using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;
    private void Awake()
    {
        for (int i = 0; i < numberOfEnemies; i++){
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-40, 40), Random.Range(-40, 40), 0), Quaternion.identity);
        }
    }
}
