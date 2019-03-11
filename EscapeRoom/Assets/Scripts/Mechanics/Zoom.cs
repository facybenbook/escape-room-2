//    using UnityEngine;
//using UnityEditor;
//using System.Collections;
//using System.Collections.Generic;

//public class Zoom : MonoBehaviour {

//    public static bool zoomed;
//    Transform cam;
//    float dist;
//    Vector3 lastCamPos;
//    public float xOffset;
//    public float yOffset;
//    public float zOffset;
//    public float xAngle;
//    public float yAngle;
//    public float zAngle;
//    public bool condTrue;
//    public CustomColliderArray colliders;
//    public GameObject zoomIn;
//    public GameObject zoomOut;

//    void Start()
//    {
//        cam = Camera.main.transform;
//        zoomed = false;
//    }

//    void Update()
//    {
//#if UNITY_EDITOR
//        if (condTrue)
//        {
//            if (Input.GetMouseButtonDown(0))
//            {
//                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//                RaycastHit hit;
//                if (Physics.Raycast(ray, out hit))
//                {
//                    foreach (Collider col in colliders.cols)
//                    {
//                        if (hit.transform == col.transform)
//                        {
//                            dist = Vector3.Distance(cam.position, transform.position);
//                            if (!zoomed)
//                            {
//                                zoomIn.SetActive(false);
//                                zoomOut.SetActive(true);
//                                lastCamPos = cam.position;
//                                cam.position = Vector3.MoveTowards(cam.position, new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), dist * 0.7f - zOffset);
//                                cam.Rotate(xAngle, yAngle, zAngle);
//                                zoomed = true;
//                                cam.parent.GetComponent<Player>().ButtonsZoomedIn();
//                            }
//                            else
//                            {
//                                zoomIn.SetActive(true);
//                                zoomOut.SetActive(false);
//                                cam.position = lastCamPos;
//                                cam.Rotate(-xAngle, -yAngle, -zAngle);
//                                zoomed = false;
//                                cam.parent.GetComponent<Player>().ButtonsZoomedOut();
//                            }
//                        }
//                    }
//                }
//            }
//        }
//#endif

//#if UNITY_IOS || UNITY_ANDROID

//        if (Input.touchCount > 0)
//        {
//            if (condTrue)
//            {
//                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
//                RaycastHit hit;
//                if (Physics.Raycast(ray, out hit))
//                {
//                    foreach (Collider col in colliders.cols)
//                    {
//                        if (hit.transform == col.transform)
//                        {
//                            if (Input.GetTouch(0).phase == TouchPhase.Began)
//                            {
//                                dist = Vector3.Distance(cam.position, transform.position);
//                                if (!zoomed)
//                                {
//                                    lastCamPos = cam.position;
//                                    cam.position = Vector3.MoveTowards(cam.position, new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), dist * 0.7f - zOffset);
//                                    cam.Rotate(xAngle, yAngle, zAngle);
//                                    zoomed = true;
//                                    cam.parent.GetComponent<Player>().ButtonsZoomedIn();
//                                    if (flare.flare != null)
//                                    {
//                                        flare.flare.brightness = flare.fZi;
//                                    }
//                                }
//                                else
//                                {
//                                    cam.position = lastCamPos;
//                                    cam.Rotate(-xAngle, -yAngle, -zAngle);
//                                    zoomed = false;
//                                    cam.parent.GetComponent<Player>().ButtonsZoomedOut();
//                                    if (flare.flare != null)
//                                    {
//                                        flare.flare.brightness = flare.fZo;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }
//#endif
//    }
//}
