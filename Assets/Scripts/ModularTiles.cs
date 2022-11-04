using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularTiles : MonoBehaviour
{

    public GameObject[] tiles;
    GameObject latestTile;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        // Uusien tilejen spawnaus
        for ( int i = 0; i < 10; i++ )
        {
            index = Random.Range(0, tiles.Length); // Tilejen randomisointi
            GameObject tempTile = Instantiate(tiles[index]);
            tempTile.transform.position = new Vector3(0, 0, 0-i*-9.95f);
            latestTile = tempTile;
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
        tempTile.transform.position = new Vector3(0, latestTile.transform.position.y, latestTile.transform.position.z+9.95f);
        latestTile = tempTile;

    }
}
