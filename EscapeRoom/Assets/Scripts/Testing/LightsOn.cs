using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOn : MonoBehaviour {

    Transform[] lights;
    public bool on;

	void Start () 
	{
        if (on)
        {
            foreach (Transform light in transform)
            {
                light.gameObject.SetActive(true);
            }
        }
	}
}
