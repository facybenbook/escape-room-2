using UnityEngine.UI;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    Transform camTF;
    Camera cam;
    public Vector3 newCamPos;
    public Vector3 newCamAngle;
    GameObject canvas;
    GameObject zoomOut;
    Image zoomOutImage;
    Button zoomOutButton;
    public bool startActive;
    public Collect collect;
    SpriteRenderer spriteRend;
    Collider col;
    //public float nearClipZoom;
    //public float farClipZoom;

    void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider>();
        camTF = Camera.main.transform;
        cam = camTF.GetComponent<Camera>();
        canvas = GameObject.Find("Canvas");
        zoomOut = canvas.transform.Find("ZoomOutButton").gameObject;
        zoomOutImage = zoomOut.GetComponent<Image>();
        zoomOutButton = zoomOut.GetComponent<Button>();
    }

    void Start()
    {
        if (!startActive)
        {
            spriteRend.enabled = false;
            col.enabled = false;
        }
        zoomOutImage.enabled = false;
        zoomOutButton.interactable = false;
    }

    void OnMouseDown()
    {
        Player.lastCamPos = camTF.position;
        Player.lastCamAngle = camTF.eulerAngles;
        zoomOutImage.enabled = true;
        zoomOutButton.interactable = true;
        camTF.position = newCamPos;
        camTF.eulerAngles = newCamAngle;
        //cam.nearClipPlane = nearClipZoom;
        //cam.farClipPlane = farClipZoom;
        cam.GetComponent<Player>().ZoomedIn();
        if (collect != null)
        {
            collect.on = true;
        }
        gameObject.SetActive(false);
        LevelManager.lastZoomIn = this;
    }

    public void Billboard()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
    }

    public void CollectDragOff()
    {
        if (collect != null)
        {
            collect.on = false;
        }
    }
}
