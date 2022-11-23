using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTiles : MonoBehaviour
{
    GameObject modular;
    ModularTiles tiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Renderer thisRender = GetComponentInChildren<Renderer>();
        
        //kun gameObject menee render alueen ulkopuolelle, se tuhotaan
        if (!thisRender.isVisible)
        {
            Destroy(gameObject);
            ModularTiles tiles;

            Debug.Log("Tile behind camera, tile destroyed");
        }
        

    }

    /*
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("Tile Destroyed!");
    }
    */



}