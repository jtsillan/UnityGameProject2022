using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneTileFunctions : MonoBehaviour
{

    TestSceneModularTiles generatedTiles;

    GameObject manager;

    bool destroyMe = false;


    void Start()
    {
        manager = GameObject.Find("ModularManager");
        generatedTiles = manager.GetComponent<TestSceneModularTiles>();

    }

    void Update()
    {
        if (destroyMe == true)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //Etsii tagill? gameobjectin
        if (collision.gameObject.tag == "TileDeleter")
        {
            
            generatedTiles.MakeNewFlatLast();
            destroyMe = true;
        }
    }      
}
