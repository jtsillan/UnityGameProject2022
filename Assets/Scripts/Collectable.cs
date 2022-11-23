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

    void FixedUpdate()
    {
        transform.Rotate(75 * Time.deltaTime, 0, 0);
    }

    //Havaitsee t�rm�ykset ker�ilt�vien kanssa
    void OnCollisionEnter(Collision collision)
    {

        //Etsii tagill� pelaajan, kutsuu scoreplusone metodia ja tuhoaa collectable objektin kun pelaaja osuu
        if (collision.gameObject.tag == "Player")
        {
            
            ScoreText.ScorePlusOne();
            Destroy(gameObject);

        }
    }


}