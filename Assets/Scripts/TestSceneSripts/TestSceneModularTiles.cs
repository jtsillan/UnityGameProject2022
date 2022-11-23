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
        
        GameObject startTile = GameObject.Find("StartTile");

        for(int i = 0; i < 5; i++)
        {
            index = Random.Range(0, flatTiles.Length); // Tilejen randomisointi
            GameObject createdTile = Instantiate(flatTiles[index]);
            Transform endSpawn = startTile.transform.Find("EndSpawnPoint");

            if(lastMadeTile != null)
            {
                Transform endPoint = lastMadeTile.transform.Find("StartSpawnPoint");
                Transform startPoint = createdTile.transform.Find("EndSpawnPoint");
                createdTile.transform.position = endPoint.transform.position;
                createdTile.transform.position = createdTile.transform.position + (createdTile.transform.position - startPoint.transform.position);

            }
            
            else
            {
                Transform startPoint = startTile.transform.Find("EndSpawnPoint");
                Transform endPoint = createdTile.transform.Find("EndSpawnPoint");
                createdTile.transform.position = startPoint.transform.position;
                createdTile.transform.position = createdTile.transform.position + (createdTile.transform.position - endPoint.transform.position);
               
            }
            
            lastMadeTile = createdTile;
        }        
    }

    public void MakeNewDownHillLast()
    {

        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, downhillTiles.Length);
            GameObject createdTile = Instantiate(downhillTiles[index]);
            Transform endPoint = lastMadeTile.transform.Find("StartSpawnPoint");
            Transform startPoint = createdTile.transform.Find("EndSpawnPoint");
            createdTile.transform.position = endPoint.transform.position;
            createdTile.transform.position = createdTile.transform.position + (createdTile.transform.position - startPoint.transform.position);
            lastMadeTile = createdTile;

        }
    }

    public void MakeNewFlatLast()
    {

        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, flatTiles.Length);
            GameObject createdTile = Instantiate(flatTiles[index]);
            Transform endPoint = lastMadeTile.transform.Find("StartSpawnPoint");
            Transform startPoint = createdTile.transform.Find("EndSpawnPoint");
            createdTile.transform.position = endPoint.transform.position;
            createdTile.transform.position = createdTile.transform.position + (createdTile.transform.position - startPoint.transform.position);
            lastMadeTile = createdTile;

        }
    }

    
    public void MakeNewUpHillLast()
    {

        for(int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, uphillTiles.Length);
            GameObject createdTile = Instantiate(uphillTiles[index]);
            Transform endPoint = lastMadeTile.transform.Find("StartSpawnPoint");
            Transform startPoint = createdTile.transform.Find("EndSpawnPoint");
            createdTile.transform.position = endPoint.transform.position;
            createdTile.transform.position = createdTile.transform.position + (createdTile.transform.position - startPoint.transform.position);
            lastMadeTile = createdTile;

        }
    }    

}
