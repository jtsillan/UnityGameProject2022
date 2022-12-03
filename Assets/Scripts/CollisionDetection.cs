
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class CollisionDetection : MonoBehaviour
{
    
    private void Start()
    {
        
    }
    //Havaitsee t�rm�ykset esteiden kanssa
    void OnCollisionEnter(Collision collision)
    {
        
        //Etsii tagill� gameobjectin
        if (collision.gameObject.tag == "Player")
        {
            //Jos tagi on sama ja t�rm�ys tapahtuu. EDIT: Vaihtaa nyt GameOverScreen sceneen kun pelaaja törmää
            if (DataManager.instance.check_Can_StoreNewHighScore())
            {
                

                SceneManager.LoadScene("HighScore");



            }
            else
            {
                SceneManager.LoadScene("GameOverScreen");
            }
        }


    }
}