using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestSceneModularTiles : MonoBehaviour
{

    [SerializeField] GameObject[] flatTiles;

    [SerializeField] GameObject[] uphillTiles;

    [SerializeField] GameObject[] downhillTiles;

    GameObject lastMadeTile;

    private int index;

    void Start()
    {
        for(int i = 0; i < flatTiles.Length; i++)
        {
            index = Random.Range(0, flatTiles.Length); // Tilejen randomisointi
            GameObject createdTile = Instantiate(flatTiles[index]);
            createdTile.transform.position = new Vector3(0, 0, 1 * 5.0f);
            Transform startSpawn = createdTile.transform.Find("StartSpawnPoint");

            if(lastMadeTile != null)
            {
                Transform endSpawn = lastMadeTile.transform.Find("EndSpawnPoint");
                //createdTile.transform.position = lastMadeTile.transform.position;
                createdTile.transform.position = endSpawn.position - startSpawn.localPosition;

            }
            lastMadeTile = createdTile;
        }
    }

    public void MakeNewTileLast()
    {
        int index2 = Random.Range(0, flatTiles.Length);
        int index3 = Random.Range(0, uphillTiles.Length);
        int index4 = Random.Range(0, downhillTiles.Length);
        GameObject createdTile = Instantiate(flatTiles[index2]);
        createdTile.transform.position = new Vector3(lastMadeTile.transform.position.x, lastMadeTile.transform.position.y, lastMadeTile.transform.position.z);
        lastMadeTile = createdTile;
    }




    /*
    [SerializeField] GameObject[] tiles;
    GameObject latestTile;
    GameObject spawnPoint;
    Vector3 spawnPosition;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("NextSpawnPoint");
        spawnPoint.transform.position = spawnPosition;

        
        // Uusien tilejen spawnaus
        for (int i = 0; i < 8; i++)
        {
            index = Random.Range(0, tiles.Length); // Tilejen randomisointi
            GameObject tempTile = Instantiate(tiles[index]);
            tempTile.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
            latestTile = tempTile;
            /*
            spawnPoint = GameObject.Find("TestTile/NextSpawnPoint");
            spawnPoint.transform.position = spawnPosition;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawnaa viimeisen tilen uudestaan
    public void NewTileLast()
    {
        index = Random.Range(0, tiles.Length);
        GameObject tempTile = Instantiate(tiles[index]);
        tempTile.transform.position = new Vector3(0, latestTile.transform.position.y, latestTile.transform.position.z + 9.95f);
        latestTile = tempTile;

    }
    */
}
