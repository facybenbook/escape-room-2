using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTrigger: MonoBehaviour {

    public GameObject zoomIn;
    public GameObject triggerZone;
    SpriteRenderer zoomSprite;
    Collider zoomCol;

    void Start()
    {
        zoomSprite = zoomIn.GetComponent<SpriteRenderer>();
        zoomCol = zoomIn.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider col)
	{
		if (col.gameObject == triggerZone)
        {
            zoomSprite.enabled = true;
            zoomCol.enabled = true;
        }
	}

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == triggerZone)
        {
            zoomSprite.enabled = false;
            zoomCol.enabled = false;
        }
    }
}
