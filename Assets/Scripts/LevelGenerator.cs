using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;
    public GameObject StartTile;

    private float Index = 0;

    private void Start()
    {

    }

    private void Update()
    {
        //pelin nopeus
        gameObject.transform.position += new Vector3(4 * Time.deltaTime, 0, 0);


        //tiilien spawnaus
        if (transform.position.x >= Index)
        {
            int RandomInt1 = Random.Range(0, 3);

            if (RandomInt1 == 1)
            {
                GameObject TempTile1 = Instantiate(Tile1, transform);
                Tile1.transform.position = new Vector3(-10, 0, 0);
            }
            else if (RandomInt1 == 0)
            {
                GameObject TempTile1 = Instantiate(Tile2, transform);
                Tile1.transform.position = new Vector3(-10, 0, 0);
            }

            int RandomInt2 = Random.Range(0, 3);

            if (RandomInt2 == 1)
            {
                GameObject TempTile2 = Instantiate(Tile1, transform);
                TempTile2.transform.position = new Vector3(-20, 0, 0);
            }
            else if (RandomInt2 == 0)
            {
                GameObject TempTile2 = Instantiate(Tile2, transform);
                TempTile2.transform.position = new Vector3(-20, 0, 0);
            }

            int RandomInt3 = Random.Range(0, 3);

            if (RandomInt3 == 1)
            {
                GameObject TempTile3 = Instantiate(Tile1, transform);
                TempTile3.transform.position = new Vector3(-30, 0, 0);
            }
            else if (RandomInt3 == 0)
            {
                GameObject TempTile3 = Instantiate(Tile3, transform);
                TempTile3.transform.position = new Vector3(-30, 0, 0);
            }

            //spawnaus nopeus
            Index = Index + 10f;
        }
    }
}