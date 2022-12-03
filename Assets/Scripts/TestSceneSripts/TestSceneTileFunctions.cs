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


    /*
    private void OnBecameInvisible()
    {
        DestroyImmediate(gameObject);
        generatedTiles.MakeNewFlatLast();
    }
    */

    /*
       private void OnBecameVisible()
       {
          //generatedTiles.MakeNewUpHillLast();
          //generatedTiles.MakeNewFlatLast();
          //generatedTiles.MakeNewDownHillLast();
          generatedTiles.MakeNewFlatLast();
           Debug.Log("On Become Visible --> Make New Tiles");
       }
      */


    void OnCollisionEnter(Collision collision)
    {
        //Etsii tagill? gameobjectin
        if (collision.gameObject.tag == "TileDeleter")
        {
            //hae kent�st� gameobjekti tagilla "Tile" ja "Obstacle"
            // laske yhteen niiden pituudet
            // jos pituudet < maksimim��r� tilej� kent�ss� suorita makenewflatlast()
            // GameObject[] tiles = GameObject.FindWithTag("Tile");
            // GameObject[] obstacles = GameObject.FindWithTag("Obstacle");
            /* if ((tiles.Lenght + obstacles.Lenght) < 25)
             * {
             *       generatedTiles.MakeNewFlatLast();
             * }
             */
             /*
             UnityEditor.EditorApplication.delayCall += () =>
             {
             };
             */
            generatedTiles.MakeNewFlatLast();
            Destroy(gameObject);

        }
    }  
    
}
