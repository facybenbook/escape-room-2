using System;
using System.Collections;
using UnityEngine;

public class DragRB : MonoBehaviour
{
    float drag;
    float angularDrag;
    float spring = 50.0f;
    float damper = 5.0f;
    float distance = 0.2f;
    public float sleepVelocity;
    Rigidbody rb;

    SpringJoint springJoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        drag = rb.drag;
        angularDrag = rb.angularDrag;
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        Camera mainCamera = Camera.main;

        RaycastHit hit = new RaycastHit();
        if (
            !Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
                             mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100,
                             Physics.DefaultRaycastLayers))
        {
            return;
        }

        if (!hit.rigidbody || hit.rigidbody.isKinematic)
        {
            return;
        }

        if (!springJoint)
        {
            var go = new GameObject("Rigidbody dragger");
            Rigidbody body = go.AddComponent<Rigidbody>();
            springJoint = go.AddComponent<SpringJoint>();
            body.isKinematic = true;
        }

        springJoint.transform.position = hit.point;
        springJoint.anchor = Vector3.zero;

        springJoint.spring = spring;
        springJoint.damper = damper;
        springJoint.maxDistance = distance;
        springJoint.connectedBody = hit.rigidbody;

        StartCoroutine("DragObject", hit.distance);
    }

    IEnumerator DragObject(float distance)
    {
        var oldDrag = springJoint.connectedBody.drag;
        var oldAngularDrag = springJoint.connectedBody.angularDrag;
        springJoint.connectedBody.drag = drag;
        springJoint.connectedBody.angularDrag = angularDrag;
        Camera mainCamera = Camera.main;
        while (Input.GetMouseButton(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            springJoint.transform.position = ray.GetPoint(distance);
            yield return null;
        }
        if (springJoint.connectedBody)
        {
            springJoint.connectedBody.drag = oldDrag;
            springJoint.connectedBody.angularDrag = oldAngularDrag;
            springJoint.connectedBody = null;
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < sleepVelocity)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
