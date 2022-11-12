using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneModularTiles : MonoBehaviour
{

    [SerializeField] GameObject[] tiles;
    GameObject latestTile;
    GameObject spawnPoint;
    Vector3 spawnPosition;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("StartTile/StartArea/NextSpawnPoint");
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
            spawnPoint.transform.position = spawnPosition;*/
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
}
