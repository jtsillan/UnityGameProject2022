using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Wheelie : MonoBehaviour
{
    public Rigidbody rb;

    public int jumpPower = 20; 

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(0, 0, -2);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 2);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 Jump = transform.up * jumpPower * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + Jump);
        }


    }
}
