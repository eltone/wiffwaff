using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {
	public float thrust = 200;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			rb.AddForce(transform.forward * thrust);
		}
	}
}
