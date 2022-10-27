using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    //Havaitsee t�rm�ykset ker�ilt�vien kanssa
    void OnCollisionEnter(Collision collision)
    {

        //Etsii tagill� pelaajan
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("Add point");

        }
    }
}