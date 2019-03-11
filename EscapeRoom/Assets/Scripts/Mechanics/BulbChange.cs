using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbChange : MonoBehaviour {

    LightManager LM;
    public LampSwitch lampSwitch;
    public GameObject oldBulbOn;
    public GameObject oldBulbOff;
    public GameObject newBulb;
    public TouchDestroy TD;

    void Awake()
    {
        LM = GameObject.Find("LightManager").GetComponent<LightManager>();
    }

    void OnDestroy()
    {
        Destroy(oldBulbOn);
        Destroy(oldBulbOff);
        TD.destroyComponents = true;
        TD.destroyScript = true;
        if (newBulb != null)
        {
            newBulb.SetActive(true);
        }
        LM.replaced = true;
        if (lampSwitch.lampOn)
        {
            lampSwitch.lampOn = false;
            LM.BulbChange();
        }
        LM.LightsPurple();
    }
}
