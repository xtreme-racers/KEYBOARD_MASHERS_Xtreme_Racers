using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using WindowsInput; 
using WindowsInput.Native; 


public class OpenCVController : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client;
    int port;
    InputSimulator input;

    string move;

    // Start is called before the first frame update
    void Start()
    {
        input = new InputSimulator();
        port = 5065;
        InitUDP();
    }


    private void InitUDP(){
        print ("UDP Initialized");

		receiveThread = new Thread (new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true; 
		receiveThread.Start ();
    }

    private void ReceiveData()
	{
		client = new UdpClient (port);
		while (true)
		{
			try
			{
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
				byte[] data = client.Receive(ref anyIP); 

				move = Encoding.UTF8.GetString(data); 
				//print (">> " + text);

			} catch(Exception e)
			{
				print (e.ToString());
			}
		}
	}


    // Update is called once per frame
    void Update()
    {
        if(move == "w"){
            // forward
            input.Keyboard.KeyPress(VirtualKeyCode.UP);
        }else if(move == "a"){
            // left
            input.Keyboard.KeyPress(VirtualKeyCode.UP);
            input.Keyboard.KeyPress(VirtualKeyCode.LEFT);
        }else if(move == "d"){
            input.Keyboard.KeyPress(VirtualKeyCode.UP);
            input.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
        }else if(move == "s"){
            input.Keyboard.KeyPress(VirtualKeyCode.DOWN);
        }
    }
}
