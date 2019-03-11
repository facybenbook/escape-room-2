using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunOff : MonoBehaviour {

	void Start () 
	{
        RenderSettings.sun = null;
	}
}
