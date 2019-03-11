using UnityEngine;

public class SetSunLight : MonoBehaviour
{
    public Transform stars;

    void Update()
    {
        stars.transform.rotation = transform.rotation;
    }
}

