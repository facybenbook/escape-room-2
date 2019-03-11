using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public GameObject lightParent;
    public GameObject lamp;
    public GameObject lampSwitch;
    public GameObject bulbOn;
    public GameObject bulbOff;
    public GameObject BLBulbOn;
    public GameObject BLBulbOff;
    public GameObject painting;
    public GameObject wallNumbers;

    public float sunMult = 0.3f;
    public float blindsMult = 0.1f;
    public float extMult;
    float windowIntensity;
    float extIntensity;

    [HideInInspector]
    public float i, x;

    public Light[] ambientLights;
    public Light[] testLights;
    public Light windowLight;
    public Light exteriorLight;
    public Light sun;

    Animation lampAnim;

    public ReflectionProbe probe;

    Renderer rend;
    Renderer paintingRend;
    Renderer wallNumberRend;

    public static bool roomLightsOn;
    [ReadOnly] public bool replaced;

    Color32 purple;
    Color32 blue;
    Color32 noAlpha;
    Color32 white;

    void Awake()
    {
        RenderSettings.sun = sun;
        roomLightsOn = false;
        windowIntensity = windowLight.intensity;
        extIntensity = exteriorLight.intensity;
        lampAnim = lampSwitch.GetComponent<Animation>();
        rend = lamp.GetComponent<Renderer>();
        paintingRend = painting.GetComponent<Renderer>();
        wallNumberRend = wallNumbers.transform.GetChild(0).GetComponent<Renderer>();
        wallNumberRend.sharedMaterial.SetColor("_Color", noAlpha);
        wallNumberRend.sharedMaterial.SetColor("_EmissionColor", Color.black);
        purple = new Color32(145, 0, 255, 255);
        blue = new Color(0, 1, 0.9f);
        noAlpha = new Color32(0, 0, 0, 0);
        white = new Color32(255, 255, 255, 255);


        foreach (Light light in ambientLights)
        {
            light.enabled = false;
        }
        foreach (Light light in testLights)
        {
            light.enabled = false;
        }
        if (probe != null)
        {
            probe.RenderProbe();
        }
    }

    void Update()
    {
        windowLight.color = sun.color;
        exteriorLight.color = sun.color;
        windowLight.intensity = windowIntensity + (i * sunMult) + (x * blindsMult);
        exteriorLight.intensity = extIntensity + (i * extMult);
    }

    public void LightsOn()
    {
        if (!replaced)
        {
            if (bulbOn != null || bulbOff != null)
            {
                bulbOn.SetActive(true);
                bulbOff.SetActive(false);
            }
            rend.material.SetColor("_EmissionColor", Color.gray);
        }
        else
        {
            if (BLBulbOn != null || BLBulbOff != null)
            {
                BLBulbOn.SetActive(true);
                BLBulbOff.SetActive(false);
            }
            rend.material.SetColor("_EmissionColor", purple);
            paintingRend.material.SetColor("_EmissionColor", blue);
            wallNumberRend.sharedMaterial.SetColor("_Color", white);
            wallNumberRend.sharedMaterial.SetColor("_EmissionColor", blue);
        }
        foreach (Light light in ambientLights)
        {
            if (light != null)
            {
                light.enabled = true;
            }
        }
        if (probe != null)
        {
            probe.RenderProbe();
        }
    }

    public void LightsOff()
    {
        if (!replaced)
        {
            if (bulbOn != null || bulbOff != null)
            {
                bulbOn.SetActive(false);
                bulbOff.SetActive(true);
            }
        }
        else
        {
            if (BLBulbOn != null || BLBulbOff != null)
            {
                BLBulbOn.SetActive(false);
                BLBulbOff.SetActive(true);
            }
            paintingRend.material.SetColor("_EmissionColor", Color.black);
            wallNumberRend.sharedMaterial.SetColor("_Color", noAlpha);
            wallNumberRend.sharedMaterial.SetColor("_EmissionColor", Color.black);
        }
        rend.material.SetColor("_EmissionColor", Color.black);
        foreach (Light light in ambientLights)
        {
            if (light != null)
            {
                light.enabled = false;
            }
        }
        if (probe != null)
        {
            probe.RenderProbe();
        }
    }

    public void BulbChange()
    {
        lampAnim.Play("lampOff");
        if (painting != null)
        {
            paintingRend.material.SetColor("_EmissionColor", Color.black);
        }
        if (wallNumberRend != null)
        {
            wallNumberRend.sharedMaterial.SetColor("_Color", noAlpha);
            wallNumberRend.sharedMaterial.SetColor("_EmissionColor", Color.black);
        }
        rend.material.SetColor("_EmissionColor", Color.black);
        foreach (Light light in ambientLights)
        {
            if (light != null)
            {
                light.enabled = false;
            }
        }
        if (probe != null)
        {
            probe.RenderProbe();
        }
    }

    public void LightsPurple()
    {
        foreach (Light light in ambientLights)
        {
            if (light != null)
            {
                light.color = purple;
            }
        }
    }
}