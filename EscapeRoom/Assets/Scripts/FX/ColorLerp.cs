using UnityEngine;
using System.Collections;

public class ColorLerp : MonoBehaviour {

    Renderer rend;
    Color32 colorDark;
    Color32 colorLight;
    Color32 lerpedColor;
    public int renderQueue;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.renderQueue = renderQueue;
        colorLight = new Color32(255, 255, 255, 255);
        colorDark = new Color32(30, 30, 30, 255);
    }

    void Update()
    {
        lerpedColor = Color32.Lerp(colorDark, colorLight, AutoIntensity.dot);
        rend.material.color = lerpedColor;
        rend.material.SetColor("_EmissionColor", Color.Lerp(Color.yellow * 4.0f, Color.black, AutoIntensity.dot + 0.7f));
    }
}
