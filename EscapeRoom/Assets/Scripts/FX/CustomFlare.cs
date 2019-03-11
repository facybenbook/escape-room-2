using UnityEngine;
using System;

[Serializable]
public class CustomFlare
{
    [HideInInspector]
    public bool addFlare;
    public LensFlare flare;
    public float fZi;
    public float fZo;
}
