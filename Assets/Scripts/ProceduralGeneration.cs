using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int chunks;
    [SerializeField] GameObject dirt;
    [SerializeField] GameObject chunkPrefab;

    // Cave Variables
    [Range(0, 100)]
    private int seed;
    [SerializeField] int smoothCycles;
    private int[,] cavePoints;
    // randFillPercent 55 is recommended
    [Range(0, 100)]
    public int randFillPercent;
    // threshold 4 is recommended
    [Range(0, 8)]
    public int threshold;
    private int numberOfChunks = 0;

    private void Awake()
    {
        seed = Random.Range(0, 1000000);
        GenerateCaves();
    }

    private void Start()
    {
        genChunks();
    }

    public void genChunks()
    {
        for (int i = 0; i < chunks; i++)
        {
            int column = Mathf.RoundToInt(Mathf.Ceil(i % 3));
            int row = Mathf.RoundToInt(Mathf.Ceil(i / 3));
            int spawnColumn = column * 20;
            int spawnRow = -row * 20;
            GameObject chunk = Instantiate(chunkPrefab, new Vector2(spawnColumn, spawnRow), Quaternion.identity);
            chunk.transform.parent = this.transform;
            chunk.name = "Chunk " + (column) + " x " + (row);

            genSingleChunk(spawnColumn, spawnRow, chunk);
        }
    }

    private void genSingleChunk(int spawnColumn, int spawnRow, GameObject chunk)
    {
        int chunkModifier = (numberOfChunks % 3) * 20;

        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                if (cavePoints[spawnColumn + x, -(spawnRow - y)] == 1)
                {
                    GameObject newBlockY = Instantiate(dirt, new Vector2(spawnColumn + x, spawnRow - y), Quaternion.identity);
                    newBlockY.transform.parent = chunk.transform;
                }
            }

            //Transform thisChunk = chunk.transform;
            //foreach (Transform child in thisChunk)
            //{
            //    child.gameObject.SetActive(false);
            //}
        }

        numberOfChunks++;
    }

    private void GenerateCaves()
    {
        int width = 60;
        int depth = (chunks / 3) * 20;

        cavePoints = new int[width, depth];

        System.Random randChoice = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < depth; y++)
            {
                if (x == 0 || y == 0 || x == width - 1 || y == depth - 1)
                {
                    cavePoints[x, y] = 1;
                }
                else if (randChoice.Next(0, 100) < randFillPercent)
                {
                    cavePoints[x, y] = 1;
                }
                else
                {
                    cavePoints[x, y] = 0;
                }
            }
        }

        for (int i = 0; i < smoothCycles; i++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < depth; y++)
                {
                    int neighboringWalls = GetNeighbors(x, y, width, depth);

                    if (neighboringWalls > threshold)
                    {
                        cavePoints[x, y] = 1;
                    }
                    else if (neighboringWalls < threshold)
                    {
                        cavePoints[x, y] = 0;
                    }
                }
            }
        }
    }


    private int GetNeighbors(int pointX, int pointY, int width, int depth)
    {
        int wallNeighbors = 0;

        for (int x = pointX - 1; x <= pointX + 1; x++)
        {
            for (int y = pointY - 1; y <= pointY + 1; y++)
            {
                if (x >= 0 && x < width && y >= 0 && y < depth)
                {
                    if (x != pointX || y != pointY)
                    {
                        if (cavePoints[x, y] == 1)
                        {
                            wallNeighbors++;
                        }
                    }
                }
                else
                {
                    wallNeighbors++;
                }
            }
        }

        return wallNeighbors;
    }
}
