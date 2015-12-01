using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {
	public float thrust = 600;
	public Rigidbody rb;
    private bool inMotion = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) && !inMotion) {
			rb.AddForce(transform.forward * thrust);
            inMotion = true;
		}
	}
}
