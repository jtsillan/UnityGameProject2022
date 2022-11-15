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


    [SerializeField] CustomController customController;

    
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

    
    private void Update()
    {
        MoveForward();
    }
    
    
    public float MoveForward()
    {

        if (customController.hallValue == true)
        {
            //Debug.Log("MoveForward() --> hallSensorValue == true");            
            float hallSensorTimeInterval = Time.realtimeSinceStartup - hallSensorLastReadTime;
            hallSensorLastReadTime = Time.realtimeSinceStartup;

            //Debug.Log("MoveForward() --> hallSensorTimeTimeInterval " + hallSensorTimeInterval);

            speed = 0.8f / hallSensorTimeInterval;

            Debug.Log("MoveForward() --> hallValue == true ---> speed " + speed);

            return speed;
        }
        else
        {
            Debug.Log("MoveForward() --> hallValue == false ---> speed 0");
            return 0.0f;        
        }
    }
    


    void MoveLeft()
    {
        transform.position += Vector3.left;
    }


    void MoveRight()
    {
        transform.position += Vector3.right;
    }

    void MoveUp()
    {
        transform.position += Vector3.up;
    }
}
