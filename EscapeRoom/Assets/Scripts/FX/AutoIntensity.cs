using UnityEngine;

public class AutoIntensity : MonoBehaviour
{
    LightManager LM;
    public TriggerParent TP;

    public Gradient nightDayColor;

    //[SerializeField]
    static public float dot;

    [SerializeField]
    float oldDot;

    [SerializeField]
    float dotDelta;

    public static bool sunRising;
    public static bool starsBright;

    public float maxIntensity;
    public float minIntensity = 0f;
    public float minPoint = -0.2f;

    public float maxAmbient = 1f;
    public float minAmbient = 0f;
    public float minAmbientPoint;

    public Gradient nightDayFogColor;
    public AnimationCurve fogDensityCurve;
    public float fogScale = 1f;

    public float dayAtmosphereThickness = 0.4f;
    public float nightAtmosphereThickness = 0.87f;

    Vector3 rotateSpeed;
    public float rotationSpeed;

    Light sun;
    Skybox sky;
    Material skyMat;

    public Transform stars;

    void Awake()
    {
        LM = GameObject.Find("LightManager").GetComponent<LightManager>();
        sun = GetComponent<Light>();
        skyMat = RenderSettings.skybox;
        TurnSunOn();
    }

    void TurnSunOn()
    {
        sun.enabled = true;
    }

    void Update()
    {
        rotateSpeed.x = rotationSpeed;
        float tRange = 1 - minPoint;
        dot = Mathf.Clamp01((Vector3.Dot(sun.transform.forward, Vector3.down) - minPoint) / tRange);
        float i;
        i = ((maxIntensity - minIntensity) * dot) + minIntensity;
        sun.intensity = i;
        LM.i = i;
        TP.i = i;

        tRange = 1 - minAmbientPoint;
        dot = Mathf.Clamp01((Vector3.Dot(sun.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
        i = ((maxAmbient - minAmbient) * dot) + minAmbient;
        RenderSettings.ambientIntensity = i;

        sun.color = nightDayColor.Evaluate(dot);
        RenderSettings.ambientLight = sun.color;

        RenderSettings.fogColor = nightDayFogColor.Evaluate(dot);
        RenderSettings.fogDensity = fogDensityCurve.Evaluate(dot) * fogScale;

        i = ((dayAtmosphereThickness - nightAtmosphereThickness) * dot) + nightAtmosphereThickness;
        skyMat.SetFloat("_AtmosphereThickness", i);

        if (dotDelta > 0)           //perfect, don't touch
        {                           //
            sunRising = true;       //
        }                           //
        else
        {                           //
            sunRising = false;      //
        }                           //

        if (dot < 0.3)/*((dot < 0.3/*) && (!sunRising))*/ //enable stars
        {
            starsBright = true;
        }
        else if (dot >= 0.3)/* if ((dot > 0.1) && (sunRising))*/
        {
            starsBright = false;
        }

        stars.transform.rotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (BreakClock.clockBroken == false)
        {
            transform.Rotate(rotateSpeed * Time.deltaTime/24);
        }
        else
        {
            transform.Rotate(-rotateSpeed * LongHand.angleDelta/2);
        }
    }
}