using UnityEngine;

public class AspectRatio : MonoBehaviour{

    public int width;
    public int height;

    void Start()
    {
        Screen.SetResolution(width, height, false);
    }
}
