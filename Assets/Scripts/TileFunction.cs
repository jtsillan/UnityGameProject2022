using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Pelin nopeus
        transform.position = transform.position + Vector3.forward * -0.015f;


        // Poistaa tilet, jotka menneet ohitte
        if (transform.position.z < -30f)
        {
            GameObject modular = GameObject.Find("ModularGenerating");
            ModularTiles mt = modular.GetComponent<ModularTiles>();
            mt.NewTileLast();
            Destroy(gameObject);
        }
        
    }
}
