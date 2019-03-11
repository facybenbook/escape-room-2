using UnityEngine;
using System.Collections;

public class LampSwitch : MonoBehaviour
{
    Animation anim;
    LightManager LM;
    AudioManager audioManager;
    [ReadOnly] public bool lampOn;

    void Awake()
    {
        anim = GetComponent<Animation>();
        LM = GameObject.Find("LightManager").GetComponent<LightManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        lampOn = false;
    }

    void OnMouseDown()
    {
        audioManager.Play("switch");
        lampOn = !lampOn;
        if (lampOn)
        {
            anim.Play("lampOn");
            LM.LightsOn();
        }
        else if (!lampOn)
        {
            anim.Play("lampOff");
            LM.LightsOff();
        }
    }
}