using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using UnityEngine;

public class WindEffect : MonoBehaviour {

    public enum FAN_RUN{
        START, STOP
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void startFan(int time)
    {
        new Thread(() => sendFanRequest("http://10.0.0.202:5000/fan?time="+time)).Start();

    }

    public void startFan(FAN_RUN type)
    {
        string stype = "start";
        if (type == FAN_RUN.STOP) stype = "stop";

        new Thread(() => sendFanRequest("http://10.0.0.202:5000/fan?type=" + stype)).Start();

    }

    private void sendFanRequest(string url)
    {
        
        string html = string.Empty;
        //string url = @"http://10.0.0.202:5000/fan";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

        Debug.Log(html);

    }
}
