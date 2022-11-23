/******************************************************************************
 * File        : Character.cs
 * Version     : 0
 * Author      : Toni Westerlund (toni.westerlund@lapinamk.com)
 * Copyright   : Lapland University of Applied Sciences
 * Licence     : MIT-Licence
 * 
 * Copyright (c) 2021 Lapland University of Applied Sciences
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 *****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private float hallSensorLastReadTime = 0;

    private float speed = 0;


    [SerializeField] float forwardSpeedMultiplier;

    [SerializeField] float upwardSpeedMultiplier;

    [SerializeField] CustomController customController;
    [SerializeField] TcpServer tcpServer;

    
    void Start()
    {
        // time interval counter for HallSensor in seconds
        hallSensorLastReadTime = Time.realtimeSinceStartup;
    }
    

    void OnEnable()
    {
        customController.OnButtonOnePressed += MoveLeft;
        customController.OnButtonTwoPressed += MoveRight;
        customController.OnBothButtonsPressed += MoveUp;
    }


    void OnDisable()
    {
        customController.OnButtonOnePressed -= MoveLeft;
        customController.OnButtonTwoPressed -= MoveRight;
        customController.OnBothButtonsPressed -= MoveUp;
    }

    
    void Update()
    {
        MoveForward();
        GetPlayerAngle();
    }

    
    public void MoveForward()
    {
        if (customController.hallValue == true)
        {           
            float hallSensorTimeInterval = Time.realtimeSinceStartup - hallSensorLastReadTime;
            hallSensorLastReadTime = Time.realtimeSinceStartup;

            speed = 0.8f / hallSensorTimeInterval;

            transform.position += Vector3.forward * speed * forwardSpeedMultiplier;
        }
    }  
    


    void MoveLeft()
    {
        transform.position += Vector3.left;

        if (transform.position.x <= -4.5f)
        {
            transform.position = new Vector3(-4.5f, transform.position.y, transform.position.z);
        }
    }


    void MoveRight()
    {
        transform.position += Vector3.right;

        if(transform.position.x >= 4.5f)
        {
            transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);
        }
    }

    void MoveUp()
    {
        transform.position += Vector3.up * upwardSpeedMultiplier;
    }

    private void GetPlayerAngle()
    {
        int angleX = (int)transform.eulerAngles.x;
        
        if(270 <= angleX && angleX < 360)
        {
            angleX = 360 - angleX;
        }
        else if(0 <= angleX && angleX <= 90)
        {
            angleX = -angleX;
        }        
        
        //tcpServer.WriteDataToBleApp(angleX);
        Debug.Log("CharacterMovement -> GetPlayerAngle --> " + angleX);
    }
}
