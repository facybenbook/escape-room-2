//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ChairZone : MonoBehaviour {

//    public GameObject zoomIn;
//    SpriteRenderer spriteRend;
//    Collider zoomCol;

//    void Start()
//    {
//        spriteRend = zoomIn.GetComponent<SpriteRenderer>();
//        zoomCol = zoomIn.GetComponent<Collider>();
//    }

//    void OnTriggerEnter(Collider col) 
//	{
//		if (col.name == "ChairZone")
//        {
//            spriteRend.enabled = true;
//            zoomCol.enabled = true;
//        }
//	}

//    void OnTriggerExit(Collider col)
//    {
//        if (col.name == "ChairZone")
//        {
//            spriteRend.enabled = false;
//            zoomCol.enabled = false;
//        }
//    }
//}
