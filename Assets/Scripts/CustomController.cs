/******************************************************************************
 * File        : CustomController.cs
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
using System.Timers;
using System;

/// <summary>
/// InputCode
/// </summary>
public enum InputCode
{
    ButtonOne = 0b0001,
    ButtonTwo = 0b0010,
    HallSensor = 0b0100

};

/// <summary>
/// CustomController
/// </summary>
public class CustomController : MonoBehaviour
{

    public bool buttonOnePressed = false;
    public bool buttonTwoPressed = false;
    [SerializeField] bool hallSensorValue = false;
    public bool hallValue = false;



    public Action<bool> OnButtonOneChanced;


    public Action OnButtonOnePressed;
    public Action OnButoonOneReleased;
    public Action OnButtonTwoPressed;
    public Action OnButtonTwoReleased;
    public Action OnBothButtonsPressed;


    // MonoBehaviour

    void Update()
    {
        ReadButtonOne();
        ReadButtonTwo();
        HallSensorIsReading();
    }



    // BUTTON READING

    /// <summary>
    /// IsButtonOnePressed
    /// </summary>
    /// <returns></returns>
    public void ReadButtonOne()
    {
        if ((int)InputCode.ButtonOne == (TcpServer.InputValue & (int)InputCode.ButtonOne) && buttonOnePressed == false)
        {
            buttonOnePressed = true;

            if (buttonTwoPressed == false)
            {
                StartCoroutine(StateMachine());
            }

        }
        else if ((int)InputCode.ButtonOne != (TcpServer.InputValue & (int)InputCode.ButtonOne) && buttonOnePressed == true)
        {
            buttonOnePressed = false;
            OnButtonOneChanced?.Invoke(buttonOnePressed);
            OnButoonOneReleased?.Invoke();
        }

    }

    /// <summary>
    /// IsButtonTwoPressed
    /// </summary>
    /// <returns></returns>
    public void ReadButtonTwo()
    {
        if ((int)InputCode.ButtonTwo == (TcpServer.InputValue & (int)InputCode.ButtonTwo) && buttonTwoPressed == false)
        {
            buttonTwoPressed = true;

            if (buttonOnePressed == false)
            {
                StartCoroutine(StateMachine());
            }

        }
        else if ((int)InputCode.ButtonTwo != (TcpServer.InputValue & (int)InputCode.ButtonTwo) && buttonTwoPressed == true)
        {
            buttonTwoPressed = false;
            OnButtonTwoReleased?.Invoke();
        }
    }


    /// <summary>
    /// HallSensorReading
    /// </summary>
    /// <returns></returns>
    public bool HallSensorIsReading()
    {
        if ((int)InputCode.HallSensor == (TcpServer.InputValue & (int)InputCode.HallSensor) && hallSensorValue == false)
        {
            hallSensorValue = true;
            hallValue = true;
            return true;
        }
        else if ((int)InputCode.HallSensor == (TcpServer.InputValue & (int)InputCode.HallSensor) && hallSensorValue == true)
        {
            hallValue = false;
            return false;
        }
        else
        {
            hallValue = false;
            hallSensorValue = false;
            return false;
        }
    }



    /// <summary>
    /// Couroutine StateMachine
    /// </summary>
    /// <returns></returns>
    IEnumerator StateMachine()
    {
        float timer = 0.2f;

        bool onePressed = buttonOnePressed;
        bool twoPressed = buttonTwoPressed;

        Debug.Log("StateMachine started (one=" + onePressed + ", two=" + twoPressed + ")");

        while (timer > 0.0f)
        {
            timer -= Time.deltaTime;

            if (buttonOnePressed && buttonTwoPressed)
            {
                onePressed = true;
                twoPressed = true;
                OnBothButtonsPressed?.Invoke();

                timer = 0f;
            }
            else if (!buttonOnePressed && !buttonTwoPressed)
            {
                timer = 0f;
            }

            yield return new WaitForEndOfFrame();
        }

        if (onePressed && !twoPressed)
        {
            OnButtonOnePressed?.Invoke();
        }
        else if (twoPressed && !onePressed)
        {
            OnButtonTwoPressed?.Invoke();
        }
    }

}
