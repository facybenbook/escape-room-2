using UnityEngine;
using System.Collections;

public class Drawer : MonoBehaviour
{
    Vector3 startScreen;
    Vector3 startWorld;
    Vector3 oldPos;
    Vector3 newPos;
    float deltaX;
    float limit;
    public float screenPercent;
    public Transform drawer;
    public bool posX;
    public bool negX;
    bool dragging = false;
    float dist;
    Transform toDrag;
    Vector3 v3;

    void Start()
    {
        drawer = drawer.transform;
        startWorld = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Player.i == 6 && !Player.down && !Player.zoomed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    startScreen = Camera.main.WorldToScreenPoint(startWorld);
                    if (posX)
                    {
                        dist = Camera.main.transform.position.z - transform.position.z;
                    }
                    else if (negX)
                    {
                        dist = transform.position.z - Camera.main.transform.position.z;
                    }
                    toDrag = transform;
                    v3 = new Vector3(Input.mousePosition.x, startScreen.y, dist);
                    dragging = true;
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (dragging)
            {
                oldPos = transform.position;
                limit = Screen.width * screenPercent;
                if (posX)
                {
                    v3 = new Vector3(Mathf.Clamp(Input.mousePosition.x, startScreen.x - limit, startScreen.x), startScreen.y, dist);
                }
                else
                {
                    v3 = new Vector3(Mathf.Clamp(Input.mousePosition.x, startScreen.x, startScreen.x + limit), startScreen.y, dist);
                }
                v3 = Camera.main.ScreenToWorldPoint(v3);
                toDrag.position = v3;
                newPos = transform.position;
                deltaX = newPos.x - oldPos.x;
                drawer.Translate(Vector3.forward * deltaX);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }
}


//#endif

//#if UNITY_ANDROID || UNITY_IOS

//        if (Input.touchCount > 0) 
//        {
//            Vector3 v3;
//            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
//            RaycastHit hit;
//            if (Physics.Raycast(ray, out hit))
//            {
//                if (hit.transform == transform)
//                {
//                    if (Input.GetTouch(0).phase == TouchPhase.Began)
//                    {
//                        startScreen = Camera.main.WorldToScreenPoint(startWorld);
//                        if (posX)
//                        {
//                            dist = Camera.main.transform.position.z - transform.position.z;
//                        }
//                        else if (negX)
//                        {
//                            dist = transform.position.z - Camera.main.transform.position.z;
//                        }
//                        toDrag = transform;
//                        v3 = new Vector3(Input.mousePosition.x, startScreen.y, dist);
//                        dragging = true;
//                    }

//                    else if (Input.GetTouch(0).phase == TouchPhase.Moved)
//                    {
//                        if (dragging)
//                        {
//                            oldPos = transform.position;
//                            if (posX)
//                            {
//                                v3 = new Vector3(Mathf.Clamp(Input.mousePosition.x, startScreen.x - limit, startScreen.x), startScreen.y, dist);
//                            }
//                            else
//                            {
//                                v3 = new Vector3(Mathf.Clamp(Input.mousePosition.x, startScreen.x, startScreen.x + limit), startScreen.y, dist);
//                            }
//                            v3 = Camera.main.ScreenToWorldPoint(v3);
//                            toDrag.position = v3;
//                            newPos = transform.position;
//                            deltaX = newPos.x - oldPos.x;
//                            drawer.Translate(Vector3.forward * deltaX);
//                        }
//                    }
//                    else if ((Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetTouch(0).phase == TouchPhase.Canceled))
//                    {
//                        dragging = false;
//                    }
//                }
//            }
//        }
//    }
//}
//#endif

    //    void Update()
    //    {
    //#if UNITY_IOS || UNITY_ANDROID
    //        if (posX)
    //        {
    //            oldPos = transform.position;
    //            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    //            cameraZ = screenPoint.z;
    //            curScreenPoint = Input.mousePosition;
    //            curScreenPoint.z = cameraZ;
    //            curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
    //            Vector3 dragPos = new Vector3(Mathf.Clamp(curPosition.x, startPosMouse.x, startPosMouse.x + limit), startPosMouse.y, startPosMouse.z);
    //            float deltaDrag = oldPos.x - dragPos.x;
    //            transform.Translate(Vector3.forward * deltaDrag);
    //            newPos = transform.position;
    //            deltaX = newPos.x - oldPos.x;
    //        }
    //        else if (negX)
    //        {
    //            oldPos = transform.position;
    //            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    //            cameraZ = screenPoint.z;
    //            curScreenPoint = Input.mousePosition;
    //            curScreenPoint.z = cameraZ;
    //            curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
    //            Vector3 dragPos = new Vector3(Mathf.Clamp(curPosition.x, startPosMouse.x - limit, startPosMouse.x), startPosMouse.y, startPosMouse.z);
    //            float deltaDrag = dragPos.x - oldPos.x;
    //            transform.Translate(Vector3.forward * deltaDrag);
    //            newPos = transform.position;
    //            deltaX = newPos.x - oldPos.x;
    //        }
    //        drawer.Translate(Vector3.forward * deltaX);
    //#endif

    //#if UNITY_ANDROID || UNITY_IOS
    //        if (Input.touchCount == 0)
    //        {
    //            updatedTransform.position = transform.position;
    //        }
    //        if (Input.touchCount > 0)
    //        {
    //            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //            RaycastHit hit;
    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                if (hit.transform == transform)
    //                {
    //                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
    //                    {
    //                        oldPos = transform.position;
    //                        Vector2 deltaPos = Input.GetTouch(0).deltaPosition;
    //                        updatedTransform.position = new Vector3(Mathf.Clamp(updatedTransform.position.x + deltaPos.x * Time.deltaTime * speed, startPos.x, startPos.x + limit), startPos.y, startPos.z);
    //                        newPos = transform.position;
    //                        deltaX = newPos.x - oldPos.x;
    //                        drawer.Translate(Vector3.forward * deltaX);
    //                    }
    //                    else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
    //                    {
    //                        updatedTransform.position = transform.position;
    //                    }
    //                }
    //            }
    //        }
    //#endif