using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneGroundMovement : MonoBehaviour
{

    //tile:n nopeus
    [SerializeField] float speed = 5;


    private void FixedUpdate()
    {
        //liike pelaajaan p�in
        Vector3 backwardMove = transform.forward * speed * Time.fixedDeltaTime;

    }
}
