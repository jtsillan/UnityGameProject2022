using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{

    private Score ScoreText;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();
    }

    //Havaitsee törmäykset keräiltävien kanssa
    void OnCollisionEnter(Collision collision)
    {

        //Etsii tagillä pelaajan, kutsuu scoreplusone metodia ja tuhoaa collectable objektin kun pelaaja osuu
        if (collision.gameObject.tag == "Player")
        {
            ScoreText.ScorePlusOne();
            Destroy(this.gameObject);
            Debug.Log("Add point");

        }
    }
}