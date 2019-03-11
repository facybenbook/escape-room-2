using UnityEngine;
using System.Collections;

public class ReflectionUpdate : MonoBehaviour
{
    private ReflectionProbe probe = null;

    // Use this for initialization
    void Start()
    {
        probe = GetComponent<ReflectionProbe>();
    }

    // Update is called once per frame
    void Update()
    {
        if (probe == null)
            return;

        if (probe.IsFinishedRendering(0))
            probe.RenderProbe();
    }
}