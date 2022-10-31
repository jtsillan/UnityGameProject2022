using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTiles : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Renderer thisRender = GetComponentInChildren<Renderer>();

        if (!thisRender.isVisible)
        {
            Destroy(gameObject);
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