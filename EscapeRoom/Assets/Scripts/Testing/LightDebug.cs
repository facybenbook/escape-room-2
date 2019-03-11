using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDebug : MonoBehaviour {

    Light[] lights;
    WaitForSeconds delay = new WaitForSeconds(3);

    void Start()
    {
        lights = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light light in lights)
        {
            Debug.Log("Start " + light.transform.name + " " + light.intensity);
        }
        StartCoroutine(DelayCheck());
    }

    IEnumerator DelayCheck()
    {
        yield return delay;
        lights = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light light in lights)
        {
            Debug.Log("Start " + light.transform.name + " " + light.intensity);
        }
    }
}
