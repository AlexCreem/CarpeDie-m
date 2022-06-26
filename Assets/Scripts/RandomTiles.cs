using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class RandomTiles : MonoBehaviour
{
    [Range(0, 100)]
    public int initChance;

    [Range(1,8)]
    public int birthLimit;

    [Range(1, 8)]
    public int deathLimit;

    [Range(1,10)]
    public int reps;
    private int count = 0;

    private int[,] terrainMap;

    public Vector3Int mapSize;

    public Tilemap topMap;
    public Tilemap botMap;
    public Tile topTile;
    public Tile botTile;

    int width;
    int height;

    public void simulate(int reps)
    {
        clearMap(false);
        width = mapSize.x;
        height = mapSize.y;

        if(terrainMap == null)
        {
            terrainMap = new int[width, height];
            initPos();
        }

        for (int i = 0; i <reps; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if(terrainMap[x,y] == 1)
                {
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
                }
                //this else
                else
                {
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
                }
            }
        }

    }

    public int[,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width, height];
        int neighbors;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);

        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                neighbors = 0;
                foreach(var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0)
                        continue;
                    if(x+b.x >= 0 && x+b.x < width && y+b.y >=0 && y+b.y < height)
                    {
                        neighbors += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                        neighbors++;
                    }
                }
                if (oldMap[x, y] == 1)
                {
                    if (neighbors < deathLimit)
                        newMap[x, y] = 0;
                    else
                    {
                        newMap[x, y] = 1;
                    }
                }

                if (oldMap[x, y] == 0)
                {
                    if (neighbors > birthLimit)
                        newMap[x, y] = 1;
                    else
                    {
                        newMap[x, y] = 0;
                    }
                }
            }
        }
        {

        }

        return newMap;
    }

    public void initPos()
    {
        for (int x = 0; x < width; x++)
        {

            for(int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 100) < initChance ? 1 : 0;
            }
        }
    }

    public void clearMap(bool complete)
    {
        topMap.ClearAllTiles();
        botMap.ClearAllTiles();

        if (complete)
        {
            terrainMap = null;
        }
    }
    // Update is called once per frame
    private void Awake()
    {
            simulate(reps);
        
        
        /* clear map
        if (Input.GetMouseButtonDown(1))
        {
            clearMap(true);
        }
        */
    }
}
