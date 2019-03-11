using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareZoom : MonoBehaviour {

    public LensFlare flare;
    public float zoomedIn;
    [ReadOnly] public float zoomedOut;

    void Start()
    {
        zoomedOut = flare.brightness;
    }

    void OnMouseDown () 
	{
        flare.brightness = zoomedIn;
	}

    public void ZoomedOut()
    {
        flare.brightness = zoomedOut;
    }
}
