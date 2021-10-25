using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCam : MonoBehaviour
{
    int currentCamIndex = 0;

    WebCamTexture tex;

    public RawImage display;

    public Text startStopText;

    public Text debug;

    public void SwapCamp_Clicked()
    {
        if (WebCamTexture.devices.Length > 0) //checks if there is a camera
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;

            if (tex != null)
            {
                StopWebCam();
                StartStopCam_Clicked();
            }
        }
    }

    public void StartStopCam_Clicked()
    {
        if (tex != null) //checks if tex excist
        {
            StopWebCam();
            startStopText.text = "Start Camera";
        }

        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            // display.material.mainTexture = tex; 
            tex.Play();
            startStopText.text = "Stop Camera";
        }
    }

    private void StopWebCam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }
}
