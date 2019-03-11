using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour
{ 
    public float cloudSpeed;
    Renderer rend;
    Color32 colorDark;
    Color32 colorLight;
    Color32 lerpedColor;
    public byte darkAlpha;
    public byte lightAlpha;
    public int renderQueue;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.renderQueue = renderQueue;
        colorLight = new Color32(255, 255, 255, lightAlpha);
        colorDark = new Color32(255, 255, 255, darkAlpha);
    }

    void Update()
    {
        transform.Rotate(Vector3.up/1000 * cloudSpeed);
        rend.material.SetColor("_TintColor", Color.Lerp(colorDark, colorLight, AutoIntensity.dot));
    }
}
