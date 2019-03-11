using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public Transform origin;
    public GameObject leftIcon;
    public GameObject rightIcon;
    public GameObject upIcon;
    public GameObject downIcon;
    public static int i;
    Vector3 camStartPos;
    public static bool up;
    public static bool down;
    public static bool reloaded;
    public static int condition;
    public static Vector3 lastCamPos;
    public static Vector3 lastCamAngle;
    ZoomIn[] zoomIns;
    FlareZoom[] flareZooms;
    public static bool zoomed;
    public Collider col;
    //AudioManager audioManager;

    //void Awake()
    //{
    //    audioManager = FindObjectOfType<AudioManager>();
    //}

    void Start()
    {
        i = 0;
        up = false;
        down = false;
        camStartPos = transform.localPosition;
        condition = 0;
        zoomIns = FindObjectsOfType(typeof(ZoomIn)) as ZoomIn[];
        flareZooms = FindObjectsOfType(typeof(FlareZoom)) as FlareZoom[];
    }

    public void LeftPointerDown()
    {
        //Click();
        col.enabled = false;
        origin.Rotate(new Vector3(0, -45, 0), Space.World);
        if (i == 0)
        {
            i = 7;
        }
        else
        {
            i = i - 1;
        }
        foreach (ZoomIn zoomIn in zoomIns)
        {
            zoomIn.Billboard();
        }
        col.enabled = true;
    }

    public void RightPointerDown()
    {
        //Click();
        col.enabled = false;
        origin.Rotate(new Vector3(0, 45, 0), Space.World);
        if (i == 7)
        {
            i = 0;
        }
        else
        {
            i = i + 1;
        }
        foreach (ZoomIn zoomIn in zoomIns)
        {
            zoomIn.Billboard();
        }
        col.enabled = true;
    }

    public void UpPointerDown()
    {
        //Click();
        col.enabled = false;
        if (!down)
        {
            up = true;
        }
        else
        {
            down = false;
        }
        origin.Rotate(-35, 0, 0);

        transform.localPosition = camStartPos;

        ButtonsOff();

        foreach (ZoomIn zoomIn in zoomIns)
        {
            zoomIn.Billboard();
        }
        col.enabled = true;
    }

    public void DownPointerDown()
    {
        //Click();
        col.enabled = false;
        if (!up)
        {
            down = true;
        }
        else
        {
            up = false;
        }

        origin.Rotate(35, 0, 0);

        if (down)
        {
            transform.localPosition = new Vector3(0, -6.75f, -3.6f);
        }
        else
        {
            transform.localPosition = camStartPos;
        }

        ButtonsOff();

        foreach (ZoomIn zoomIn in zoomIns)
        {
            zoomIn.Billboard();
        }
        col.enabled = true;
    }

    //void Click()
    //{
    //    audioManager.Play("click");
    //}

    void ButtonsOff()
    {
        if (up)
        {
            upIcon.SetActive(false);
        }
        else if (down)
        {
            downIcon.SetActive(false);
        }
        else
        {
            leftIcon.SetActive(true);
            rightIcon.SetActive(true);
            upIcon.SetActive(true);
            downIcon.SetActive(true);
        }
    }

    public void ZoomedIn()
    {
        leftIcon.SetActive(false);
        rightIcon.SetActive(false);
        upIcon.SetActive(false);
        downIcon.SetActive(false);
        zoomed = true;
    }

    public void ZoomedOut()
    {
        if (up)
        {
            upIcon.SetActive(false);
        }
        else
        {
            upIcon.SetActive(true);
        }
        if (down)
        {
            downIcon.SetActive(false);
        }
        else
        {
            downIcon.SetActive(true);
        }
        leftIcon.SetActive(true);
        rightIcon.SetActive(true);

        zoomed = false;

        foreach (FlareZoom flareZoom in flareZooms)
        {
            flareZoom.ZoomedOut();
        }
    }

    //public void RestartLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    reloaded = true;
    //}

    public void Quit()
    {
        Application.Quit();
    }
}