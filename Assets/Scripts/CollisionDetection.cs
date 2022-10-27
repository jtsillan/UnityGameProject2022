
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
    //Havaitsee törmäykset esteiden kanssa
    void OnCollisionEnter(Collision collision)
    {

        //Etsii tagillä gameobjectin
        if (collision.gameObject.tag == "Obstacle")
        {
            //Jos tagi on sama ja törmäys tapahtuu
            SceneManager.LoadScene("Randomized_Tiles");
            Debug.Log("Collision detected");
        }
    }
}