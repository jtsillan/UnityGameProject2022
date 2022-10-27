using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    //Havaitsee törmäykset keräiltävien kanssa
    void OnCollisionEnter(Collision collision)
    {

        //Etsii tagillä pelaajan
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("Add point");

        }
    }
}