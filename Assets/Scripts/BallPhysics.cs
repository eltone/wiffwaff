using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {
	public float Thrust = 1200;
	public Rigidbody BallRigidBody;
    private bool inMotion = false;
	private bool mouseDown = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			mouseDown = true;
		}
		else {
			mouseDown = false;
		}
	}

	void FixedUpdate () {
		if (mouseDown && !inMotion) {
			BallRigidBody.AddForce(transform.forward * Thrust * Time.fixedDeltaTime, mode: ForceMode.VelocityChange);
            inMotion = true;
		}
	}
}
