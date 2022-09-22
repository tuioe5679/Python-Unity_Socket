using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System;

public class SocketClient : MonoBehaviour
{
   string host = "192.168.101.101";
    int port = 8000;
    byte[] data = new byte[1024];
    NetworkStream stream;
    TcpClient client;

    private void Start()
    {
        client = new TcpClient(host, port);
    }

    public void off()
    {
        try
        {
            stream = client.GetStream();
            data = sendMessage("LED 1 OFF");
            stream.Write(data, 0, data.Length);
        }

        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void on()
    {
        try
        {
            stream = client.GetStream();
            data = sendMessage("LED 1 ON");
            stream.Write(data, 0, data.Length);
        }

        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public byte[] sendMessage(String message)
    {
        return Encoding.UTF8.GetBytes(message);
    }
    }

    public byte[] sendMessage(String message)
    {
        data = Encoding.UTF8.GetBytes(message);
        return data;
    }
}
