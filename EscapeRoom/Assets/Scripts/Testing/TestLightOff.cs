using UnityEngine;
using System.Collections;

public class TestLightOff : MonoBehaviour {

    public Light testLight;
    public bool off;

    //void Awake()
    //{
    //    off = false;
    //}

    void Start()
    {
        if (off)
        {
            testLight.enabled = false;
        }
    }

}
