
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
    //Havaitsee t�rm�ykset esteiden kanssa
    void OnCollisionEnter(Collision collision)
    {

        //Etsii tagill� gameobjectin
        if (collision.gameObject.tag == "Obstacle")
        {
            //Jos tagi on sama ja t�rm�ys tapahtuu
            SceneManager.LoadScene("Randomized_Tiles");
            Debug.Log("Collision detected");
        }
    }
}