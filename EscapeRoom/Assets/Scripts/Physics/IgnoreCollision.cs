using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    Collider col;
    public GameObject[] gameObjects;
    public string[] tags;
    public LayerMask[] layers;

    void Start()
    {
        col = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject go in gameObjects)
        {
            if (collision.gameObject == go)
            {
                Physics.IgnoreCollision(collision.collider, col);
            }
        }
        foreach (string tag in tags)
        {
            if (collision.gameObject.tag == tag)
            {
                Physics.IgnoreCollision(collision.collider, col);
            }
        }
        foreach (LayerMask layer in layers)
        {
            if (collision.gameObject.layer == layer)
            {
                Physics.IgnoreCollision(collision.collider, col);
            }
        }
    }
}