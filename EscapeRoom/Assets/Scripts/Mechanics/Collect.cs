using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject icon;
    public GameObject zoomDisable;
    //public GameObject zoomDisableTrigger;
    Transform collection;
    Transform newParent;
    Vector3 collectPos;
    public Vector3 bigScale;
    public Collider collectZone;
    Collider collectCol;
    MeshCollider meshCol;
    Rigidbody rb;
    public bool on;
    public bool destroyDrag;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        newParent = Camera.main.transform;
        collection = Camera.main.transform.Find("Collection");
        collectCol = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        icon.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col == collectZone)
        {
            on = true;
        }
        //if (col.gameObject == zoomDisableTrigger)
        //{
        //    zoomDisable.GetComponent<Collider>().enabled = false;
        //    zoomDisable.GetComponent<SpriteRenderer>().enabled = false;
        //}
    }

    void OnMouseDown()
    {
        if (on)
        {
            if (rb != null)
            {
                rb.isKinematic = true;
                Destroy(rb);
            }
            if (destroyDrag && GetComponent<DragRB>() != null)
            {
                Destroy(GetComponent<DragRB>());
            }
            audioManager.Play("collect");
            icon.SetActive(true);
            transform.localScale = bigScale;
            transform.position = collection.position;
            transform.SetParent(newParent);
            Destroy(collectCol);
            meshCol = gameObject.AddComponent<MeshCollider>();
            meshCol.convex = false;
            //transform.gameObject.layer = 20;
            if (zoomDisable != null)
            {
                zoomDisable.GetComponent<Collider>().enabled = false;
                zoomDisable.GetComponent<SpriteRenderer>().enabled = false;
            }
            Destroy(this);
        }
    }
}