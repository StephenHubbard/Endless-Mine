using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public GameObject blueJelly, bat;

    public void spawnEnemies(Vector2 coordinate, GameObject chunk)
    {
        int spawnEnemyInt = Random.Range(1, 40);
        if (spawnEnemyInt == 1)
        {
            GameObject enemy = Instantiate(blueJelly, coordinate, Quaternion.identity);
            enemy.transform.parent = chunk.transform;
        }
        if (spawnEnemyInt == 2)
        {
            GameObject enemy = Instantiate(bat, coordinate, Quaternion.identity);
            enemy.transform.parent = chunk.transform;
        }
    }
}
