using UnityEngine;
using System.Collections;

public class DragBooks : MonoBehaviour
{
    Rigidbody rb;
    bool isDragging;
    Vector3 moveTo;
    public float dragDamper;
    public float speed;
    Plane dragPlane;
    float dist;
    bool dropped;
    public bool stopped;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dropped = false;
    }

    void Update()
    {
        if (!BookWatch.safeUnlocked)
        { if (rb.IsSleeping() && dropped)
            {
                stopped = true;
                dropped = false;
            }
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isDragging = true;
                    rb.useGravity = false;
                    dragPlane = new Plane(-ray.direction.normalized, hit.point);
                    if (!BookWatch.safeUnlocked)
                    {
                        stopped = false;
                        BookWatch.booksSleeping--;
                    }
                }
            }
        }
        if (isDragging)
        {
            var hasHit = dragPlane.Raycast(ray, out dist);
            if (hasHit)
            {
                moveTo = ray.GetPoint(dist);
            }
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.useGravity = true;
        if (!BookWatch.safeUnlocked)
        {
            dropped = true;
            BookWatch.booksSleeping++;
        }
    }

    void FixedUpdate()
    {
        if (!isDragging) return;
        var velocity = (moveTo - transform.position) * speed;
        rb.velocity = Vector3.Lerp(rb.velocity, velocity, dragDamper * Time.deltaTime);
    }
}
