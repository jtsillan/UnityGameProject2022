using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneTileFunctions : MonoBehaviour
{    

    TestSceneModularTiles generatedTiles;

    GameObject manager;


    void Start()
    {
        manager = GameObject.Find("ModularManager");
        generatedTiles = manager.GetComponent<TestSceneModularTiles>();
    }


    private void OnBecameInvisible()
    {
        generatedTiles.MakeNewUpHillLast();
        generatedTiles.MakeNewFlatLast();
        generatedTiles.MakeNewDownHillLast();
        generatedTiles.MakeNewFlatLast();
        Destroy(gameObject);
        Debug.Log("On Become invisible");
    }

}
