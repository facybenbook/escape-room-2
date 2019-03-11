using UnityEngine;
using System.Collections;

public class StarFade : MonoBehaviour {

    ParticleSystem ps;
    ParticleSystem.EmissionModule em;
    ParticleSystem.ColorOverLifetimeModule col;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        em = ps.emission;
        col = ps.colorOverLifetime;
    }

    void Update()
    {
        if (AutoIntensity.starsBright)
        {
            em.enabled = true;
            col.enabled = false;
        }
        else if (!AutoIntensity.starsBright)
        {
            em.enabled = false;
            col.enabled = true;
        }
    }
}
