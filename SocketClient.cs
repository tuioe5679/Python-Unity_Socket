using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System;

public class SocketClient : MonoBehaviour
{
    string host = "127.0.0.1";
    int port = 8000;
    byte[] data = new byte[1024];
    NetworkStream stream;
    TcpClient client;

    private void Start()
    {
        ConnectTcpServer();
        client = new TcpClient(host, port);
    }

    public void ConnectTcpServer()
    {
        try
        {
            stream = client.GetStream();

            sendMessage("메시지 보냅니다");
            stream.Write(data, 0, data.Length);
        }

        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public byte[] sendMessage(String message)
    {
        data = Encoding.UTF8.GetBytes(message);
        return data;
    }
}
