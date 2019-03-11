using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public float force;
    Rigidbody rb;

	void Start () 
	{
        rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () 
	{
        rb.AddForce(Physics.gravity * force, ForceMode.Acceleration);
	}
}
