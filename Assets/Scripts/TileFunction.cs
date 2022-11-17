using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFunction : MonoBehaviour
{

    [SerializeField] float Velocity = 0.1f;

    GameObject modular;

    ModularTiles tiles;

    // Start is called before the first frame update
    void Start()
    {

        modular = GameObject.Find("ModularGenerating");
        tiles = modular.GetComponent<ModularTiles>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Pelin nopeus
        transform.position = transform.position + Vector3.forward * Velocity;

        
        // Poistaa tilet, jotka menneet ohitte
        if (transform.position.z < -30f)
        {
            tiles.NewTileLast();
            Destroy(gameObject);
        }
        
        
    }
}
