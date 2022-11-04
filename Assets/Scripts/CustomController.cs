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
    bool buttonOnePressed = false;
    bool buttonTwoPressed = false;
    bool hallSensorValue= false;

    /// <summary>
    /// IsButtonOnePressed
    /// </summary>
    /// <returns></returns>
    public bool IsButtonOnePressed()
    {
        if((int)InputCode.ButtonOne == (TcpServer.InputValue & (int)InputCode.ButtonOne) && buttonOnePressed == false)
        {
            buttonOnePressed = true;
            return true;
        }
        else if ((int)InputCode.ButtonOne == (TcpServer.InputValue & (int)InputCode.ButtonOne) && buttonOnePressed == true )
        {
            
        }
        else { buttonOnePressed = false; }

        return false;
    }

    /// <summary>
    /// IsButtonTwoPressed
    /// </summary>
    /// <returns></returns>
    public bool IsButtonTwoPressed()
    {
        if((int)InputCode.ButtonTwo == (TcpServer.InputValue & (int)InputCode.ButtonTwo) && buttonTwoPressed == false)
        {
            buttonOnePressed = true;
            return true;
        }
        else if ((int)InputCode.ButtonTwo == (TcpServer.InputValue & (int)InputCode.ButtonTwo) && buttonTwoPressed == true)
        {

        }
        else { buttonTwoPressed = false; }

        return false;
    }

    /// <summary>
    /// IsHallSensorReading
    /// </summary>
    /// <returns></returns>
    public bool IsHallSensorReading()
    {
        if((int)InputCode.HallSensor == (TcpServer.InputValue & (int)InputCode.HallSensor) && hallSensorValue == false)
        {
            hallSensorValue = true;
            return true;
        }
        else if ((int)InputCode.HallSensor == (TcpServer.InputValue & (int)InputCode.HallSensor) && hallSensorValue == true)
        {

        }
        else { hallSensorValue = false; }

        return false;
    }


}
