using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public GameObject blueJelly;
    //public GameObject enemyContainer;

    public void spawnEnemies(Vector2 coordinate, GameObject chunk)
    {
        int spawnEnemyInt = Random.Range(1, 20);
        if (spawnEnemyInt == 1)
        {
            GameObject enemy = Instantiate(blueJelly, coordinate, Quaternion.identity);
            enemy.transform.parent = chunk.transform;
        }
    }
}
