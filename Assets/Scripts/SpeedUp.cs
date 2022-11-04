
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float turnSpeed = 50f;

    public float _Velocity = 0.0f;      // Current Travelling Velocity
    public float _MaxVelocity = 1.0f;   // Maxima Velocity
    public float _Acc = 0.0f;           // Current Acceleration
    public float _AccSpeed = 0.1f;      // Amount to increase Acceleration with.
    public float _MaxAcc = 1.0f;        // Max Acceleration
    public float _MinAcc = -1.0f;       // Min Acceleration

    //sivuttaisliike ja sen nopeutus
    public float horizontalInput;
    public float horizontalMultiplier = 2;



    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
            _Acc += _AccSpeed;

        if (Input.GetKey(KeyCode.DownArrow))
            _Acc -= _AccSpeed;

        if (Input.GetKey(KeyCode.LeftArrow))
            -transform.forward(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            -transform.forward(Vector3.up, turnSpeed * Time.deltaTime);


        if (_Acc > _MaxAcc)
            _Acc = _MaxAcc;
        else if (_Acc < _MinAcc)
            _Acc = _MinAcc;

        _Velocity += _Acc;

        if (_Velocity > _MaxVelocity)
            _Velocity = _MaxVelocity;
        else if (_Velocity < -_MaxVelocity)
            _Velocity = -_MaxVelocity;

        transform.Translate(Vector3.forward * _Velocity * Time.deltaTime);
    }
}