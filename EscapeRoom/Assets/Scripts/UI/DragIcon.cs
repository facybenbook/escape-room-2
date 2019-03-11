using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DragIcon : MonoBehaviour
{
    public GameObject item;
    public GameObject drop;
    public Transform finalParent;
    Dropped dropped;
    Image image;
    Vector3 mousePos;
    Vector3 itemPos;
    Vector3 collectPos;
    Vector3 pivotPos;
    Vector3 collectRot;
    public float angleOffset;
    public Vector3 finalPos;
    public Vector3 finalRot;
    public Vector3 finalScale;
    public Vector3 finalColScale;
    bool dropTrue;
    bool spin;
    public int i;
    public bool destroyDrop;
    Transform pivot;
    Transform collection;
    BoxCollider boxCol;

    void Start()
    {
        image = GetComponent<Image>();
        dropTrue = false;
        dropped = item.GetComponent<Dropped>();
        collection = Camera.main.transform.Find("Collection");
        pivot = Camera.main.transform.Find("Pivot");
    }

    public void OnPointerDown()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        collectPos = collection.position;
        pivotPos = pivot.position;
        collectRot = collection.localEulerAngles;
        collectRot.z += angleOffset;
        item.transform.localEulerAngles = collectRot;
        spin = true;
        StartCoroutine(ItemSpin());
    }

    public void OnDrag()
    {
        image.enabled = false;
        item.transform.SetParent(null);
        item.transform.SetParent(pivot);
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        itemPos = Camera.main.ScreenToWorldPoint(mousePos);
        pivot.position = itemPos;
        if (Player.i == i)
        {
            item.GetComponent<MeshCollider>().enabled = false;
        }
        else
        {
            item.GetComponent<MeshCollider>().enabled = true;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == drop.transform)
            {
                dropTrue = true;
            }
            else
            {
                dropTrue = false;
            }
        }
    }

    public void OnPointerUp()
    {
        pivot.transform.position = pivotPos;
        if (dropTrue)
        {
            item.transform.SetParent(finalParent);
            item.transform.position = finalPos;
            item.transform.eulerAngles = finalRot;
            item.transform.localScale = finalScale;
            Destroy(item.GetComponent<MeshCollider>());
            boxCol = item.AddComponent<BoxCollider>();
            boxCol.size = finalColScale;
            if (dropped != null)
            {
                dropped.isDropped = true;
            }
            if (destroyDrop)
            {
                Destroy(drop);
            }
            Destroy(gameObject);
        }
        else
        {
            image.enabled = true;
            item.transform.SetParent(Camera.main.transform);
            item.transform.position = collectPos;
            spin = false;
        }
        item.GetComponent<MeshCollider>().enabled = true;
    }

    IEnumerator ItemSpin()
    {
        while (spin)
        {
            pivot.transform.Rotate(0, 30 * Time.deltaTime, 0, Space.Self);
            yield return null;
        }
    }
}
