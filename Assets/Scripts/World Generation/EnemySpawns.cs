using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public GameObject blueJelly, bat;


    private void Awake()
    {
    }

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

    public void NewDaySpawnEnemies()
    {
        Chunk[] chunks = FindObjectsOfType<Chunk>();

        foreach (Chunk child in chunks)
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    int spawnEnemyInt = Random.Range(1, 40);
                    Vector2 coordinate = new Vector2(child.transform.position.x + x, child.transform.position.y - y);

                    if (spawnEnemyInt == 1)
                    {
                        GameObject enemy = Instantiate(blueJelly, coordinate, Quaternion.identity);
                        enemy.transform.parent = child.transform;
                    }
                    if (spawnEnemyInt == 2)
                    {
                        GameObject enemy = Instantiate(bat, coordinate, Quaternion.identity);
                        enemy.transform.parent = child.transform;
                    }
                }
            }
        }
    }

    
}
