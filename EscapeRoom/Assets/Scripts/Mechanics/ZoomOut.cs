using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class ZoomOut : MonoBehaviour
{
    Image image;
    Button button;
    Transform camTF;
    Camera cam;

    void Awake()
    { 
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        camTF = Camera.main.transform;
        cam = camTF.GetComponent<Camera>();
    }

    void Start()
    {
        image.enabled = false;
        button.interactable = false;
    }

    public void ZoomOutFunc()
    {
        var lzi = LevelManager.lastZoomIn;
        camTF.position = Player.lastCamPos;
        camTF.eulerAngles = Player.lastCamAngle;
        lzi.gameObject.SetActive(true);
        lzi.CollectDragOff();
        image.enabled = false;
        button.interactable = false;
        cam.GetComponent<Player>().ZoomedOut();
    }
}