using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int chunks;
    [SerializeField] GameObject dirt, stone, iron, diamond, coal, dirtLevel2;
    [SerializeField] GameObject chunkPrefab;
    EnemySpawns enemySpawns;

    GameSession gameSession;

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
        enemySpawns = FindObjectOfType<EnemySpawns>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Start()
    {
        if (gameSession.isNewGame)
        {
            GenerateCaves();
            GenChunks();
            SpreadMinerals();
        }
    }

    // Debug button
    public void GenerateWorld()
    {
        GenerateCaves();
        GenChunks();
        SpreadMinerals();
    }

    public void GenChunks()
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
                // For passing to EnemySpawn.cs
                Vector2 coordinate = new Vector2(spawnColumn + x, spawnRow - y);

                int mineralGen = Random.Range(0, 101);

                if (cavePoints[spawnColumn + x, -(spawnRow - y)] == 1 && mineralGen < 10)
                {
                    GameObject newBlockY = Instantiate(stone, new Vector2(spawnColumn + x, spawnRow - y), Quaternion.identity);
                    newBlockY.transform.parent = chunk.transform;
                    //newBlockY.AddComponent<>();
                }
                else if (cavePoints[spawnColumn + x, -(spawnRow - y)] == 1 && mineralGen == 10)
                {
                    GameObject newBlockY = Instantiate(iron, new Vector2(spawnColumn + x, spawnRow - y), Quaternion.identity);
                    newBlockY.transform.parent = chunk.transform;
                }
                else if (cavePoints[spawnColumn + x, -(spawnRow - y)] == 1 && mineralGen == 11)
                {
                    GameObject newBlockY = Instantiate(coal, new Vector2(spawnColumn + x, spawnRow - y), Quaternion.identity);
                    newBlockY.transform.parent = chunk.transform;
                }
                else if (cavePoints[spawnColumn + x, -(spawnRow - y)] == 1 && mineralGen == 12 && (y + -spawnRow) > 40)
                {
                    GameObject newBlockY = Instantiate(diamond, new Vector2(spawnColumn + x, spawnRow - y), Quaternion.identity);
                    newBlockY.transform.parent = chunk.transform;
                }
                else if (cavePoints[spawnColumn + x, -(spawnRow - y)] == 1 && (y + -spawnRow) > 40)
                {
                    GameObject newBlockY = Instantiate(dirtLevel2, new Vector2(spawnColumn + x, spawnRow - y), Quaternion.identity);
                    newBlockY.transform.parent = chunk.transform;
                }
                else if (cavePoints[spawnColumn + x, -(spawnRow - y)] == 1)
                {
                    GameObject newBlockY = Instantiate(dirt, new Vector2(spawnColumn + x, spawnRow - y), Quaternion.identity);
                    newBlockY.transform.parent = chunk.transform;
                }
                else
                {
                    if (gameSession.isNewGame)
                    {
                        enemySpawns.spawnEnemies(coordinate, chunk);
                    }
                }
            }
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


    private void SpreadMinerals()
    {
        // STONE
        int stoneStarterInt = 0;
        int spreadStoneMultiplier = 3;
        int stoneRarity = 3;

        if (stoneStarterInt < spreadStoneMultiplier)
        {
            GenMinerals(stone, "Stone(Clone)", stoneRarity);
            stoneStarterInt++;
        }

        // DIAMONDS
        int diamondStarterInt = 0;
        int spreaddiamondMultiplier = 2;
        int diamondRarity = 8;

        if (diamondStarterInt < spreaddiamondMultiplier)
        {
            GenMinerals(diamond, "Diamond(Clone)", diamondRarity);
            diamondStarterInt++;
        }

        // IRON
        int ironStarterInt = 0;
        int spreadIronMultiplier = 2;
        int ironRarity = 5;

        if (ironStarterInt < spreadIronMultiplier)
        {
            GenMinerals(iron, "Iron(Clone)", ironRarity);
            ironStarterInt++;
        }

        // COAL
        int coalStarterInt = 0;
        int spreadCoalMultiplier = 2;
        int coalRarity = 5;

        if (ironStarterInt < spreadCoalMultiplier)
        {
            GenMinerals(iron, "Iron(Clone)", coalRarity);
            coalStarterInt++;
        }
    }

        private void GenMinerals(GameObject mineral, string mineralString, int mineralRarity)
    {
        int width = 60;
        int depth = (chunks / 3) * 20;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < depth; y++)
            {
                Vector2 mineralLocation = new Vector2(x, -y);
                Collider2D[] getBlockType = Physics2D.OverlapCircleAll(mineralLocation, 0.1f);
                if (getBlockType.Length > 0)
                {
                    if (getBlockType[0].gameObject.name == mineralString)
                    {
                        Vector2 gemLocation = getBlockType[0].gameObject.transform.position;
                        Collider2D[] gemIsTouching = Physics2D.OverlapCircleAll(gemLocation, .6f);
                        if (gemIsTouching.Length > 0)
                        {

                            for (int i = 0; i < gemIsTouching.Length; i++)
                            {
                                if (gemIsTouching[i].gameObject.name != mineralString)
                                {
                                    bool shouldSpreadGem = false;
                                    if (Random.Range(0, mineralRarity) == 1)
                                    {
                                        shouldSpreadGem = true;
                                    }

                                    if (shouldSpreadGem == true)
                                    {
                                        GameObject newMineral = Instantiate(mineral, gemIsTouching[i].transform.position, Quaternion.identity);
                                        newMineral.transform.parent = gemIsTouching[i].transform.parent;
                                        Destroy(gemIsTouching[i].gameObject);
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
    }


}
