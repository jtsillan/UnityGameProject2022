/******************************************************************************
 * File        : TcpServer.cs
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class TcpServer : MonoBehaviour
{
	/// <summary>
	/// 
	/// </summary>
	public static TcpServer instance;

	/// <summary> 	
	/// TCPListener to listen for incomming TCP connection 	
	/// requests. 	
	/// </summary> 	
	private TcpListener tcpListener;
	/// <summary> 
	/// Background thread for TcpServer workload. 	
	/// </summary> 	
	private Thread tcpListenerThread;
	/// <summary> 	
	/// Create handle to connected tcp client. 	
	/// </summary> 	
	private TcpClient connectedTcpClient;

	/// <summary>
	/// run
	/// </summary>
	private bool run;

	/// <summary>
	/// InputValue
	/// </summary>
	public static int InputValue;

	/// <summary>
	/// Ble Client
	/// </summary>
	private NetworkStream client;

    /// <summary>
    /// Start
    /// </summary>
    void Start()
	{
		run = true;
		// Start TcpServer background thread 		
		tcpListenerThread = new Thread(new ThreadStart(ListenForIncommingRequests));
		tcpListenerThread.IsBackground = true;
		tcpListenerThread.Start();
	}

	/// <summary>
	/// Awake
	/// </summary>
	private void Awake()
	{
		if (TcpServer.instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}

	/// <summary>
	/// OnDestroy
	/// </summary>
	private void OnDestroy()
    {
		run = false;
		tcpListenerThread.Abort();
		tcpListener.Stop();
		connectedTcpClient.Close();
	}

    /// <summary>
    /// Update
    /// </summary>
    void Update()
	{

	}

	/// <summary>
	/// WriteDataToBleApp, 
	/// </summary>
	/// <param name="angle"></param>
	public void WriteDataToBleApp(int angle)
	{
		byte[] data = BitConverter.GetBytes(angle);

		if(client != null)
		{
			Debug.Log(data.Length);


			client.Write(data,0, data.Length);
		}

    }


	/// <summary> 	
	/// Runs in background TcpServerThread; Handles incomming TcpClient requests 	
	/// </summary> 	
	private void ListenForIncommingRequests()
	{
		try
		{
			// Create listener on localhost port 8052. 			
			tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
			tcpListener.Start();
			Debug.Log("Server is listening");
			Byte[] bytes = new Byte[1024];
			while (run)
			{
				using (connectedTcpClient = tcpListener.AcceptTcpClient())
				{
					// Get a stream object for reading 					
					using (NetworkStream stream = connectedTcpClient.GetStream())
					{
						client = stream;

                        int length;
						// Read incomming stream into byte arrary. 						
						while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
						{
						
							InputValue = BitConverter.ToInt32(bytes, 0);

							Debug.LogError(InputValue + " len " + length);
							
							// Sending data to ble gatt
							//stream.Write(bytes, 0 , bytes.Length);
		
						}
					}
				}
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("SocketException " + socketException.ToString());
		}
	}
}
