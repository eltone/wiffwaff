using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {
	public float thrust = 1200;
	private Rigidbody _rb;
    private bool inMotion = false;
	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) && !inMotion) {
			_rb.AddForce(transform.forward * thrust);
            inMotion = true;
		}
	}
}
