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
    float lastAccepted = 0;

    /// <summary>
    /// customController
    /// </summary>
    [SerializeField] private CustomController customController;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        lastAccepted = Time.realtimeSinceStartup;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

        
        if(customController.IsButtonOnePressed())
        {
        
        }

        else if(customController.IsButtonTwoPressed())
        {
            
        }

        else if(customController.IsHallSensorReading())
        {
            Debug.Log("Character - Update() -> timeinterval " + (Time.realtimeSinceStartup - lastAccepted));

            lastAccepted = Time.realtimeSinceStartup;
        }



       // Debug.Log("Character - Update() -> Button Two Pressed " + customController.IsButtonTwoPressed());
       // Debug.Log("Character - Update() -> Hall Sensor Reading Pressed " + customController.IsHallSensorReading());
    }
}
