using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Diagnostics;
using System.IO;

namespace com.berkecuhadar.unitydialoguegenerator.Runtime{
public class UDGCore
{
    private TcpClient client;
    private NetworkStream stream;
    private byte[] data;
    private string serverText;

    private string serverPath = Path.Combine(Application.streamingAssetsPath, "server/server.exe");

    public void Init(string server, int port, int model)
    {
        StartServer();
        Connect(server, port);
        SelectModel(model);
    }

    public void StartServer()
    {
        Process process = new Process();
        process.StartInfo.FileName = serverPath;
        process.Start();

    }


    public void Connect(string server, int port)
    {
        try
        {
            client = new TcpClient(server, port);
            stream = client.GetStream();
            UnityEngine.Debug.Log("Connected to server.");
        }
        catch (SocketException e)
        {
            UnityEngine.Debug.LogError("SocketException: " + e);
        }
    }
    public void SelectModel(int index)
    {
        string model = "2";

        if (index == 1)
        {
            model = "1";
            UnityEngine.Debug.Log("Model is smallModel");
        }
        else if (index == 2)
        {
            model = "2";
            UnityEngine.Debug.Log("Model is mediumModel");
        }
        else if (index == 3)
        {
            model = "3";
            UnityEngine.Debug.Log("Model is largeModel");
        }
        try
        {
            if (client == null || !client.Connected)
            {
                UnityEngine.Debug.LogError("Client is not connected.");
                
            }

            data = Encoding.ASCII.GetBytes(model);
            stream.Write(data, 0, data.Length);
            UnityEngine.Debug.Log("Sent: " + model);
        }
        catch (Exception e)
        {
           UnityEngine.Debug.LogError("Exception: " + e);
        }


        
    }
    public string GenerateText(string input)
    {
        try
        {
            if (client == null || !client.Connected)
            {
                UnityEngine.Debug.LogError("Client is not connected.");
                
            }

            data = Encoding.ASCII.GetBytes(input);
            stream.Write(data, 0, data.Length);
            UnityEngine.Debug.Log("Sent: " + input);

            data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            serverText = Encoding.ASCII.GetString(data, 0, bytes);
            UnityEngine.Debug.Log("Received: " + serverText);
            return serverText;
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Exception: " + e);
            return e.Message;
        }
    }
    


    public void CloseConn()
    {
        // Close everything properly
        if (stream != null)
            stream.Close();
        if (client != null)
            client.Close();
    }
}
}
