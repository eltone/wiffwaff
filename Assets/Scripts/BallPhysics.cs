using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {
	public float Thrust;
	public float DistanceFactor;
	private Rigidbody _rb;
    private bool inMotion = false;
	private bool mouseDown = false;

	void Start () {
		_rb = GetComponent<Rigidbody>();
	}
	
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
			_rb.AddForce(0, 0, Thrust * Time.fixedDeltaTime, mode: ForceMode.VelocityChange);
            inMotion = true;
		}
	}

	void OnCollisionEnter (Collision collision) {
		if(collision.collider.CompareTag("Player")) {
			//change the normal of the collsion based on how far from the center of the paddle the collision is
			ContactPoint contact = collision.contacts[0];
			Vector3 localPoint = collision.collider.transform.InverseTransformPoint(contact.point);
			Vector3 normalizedLocal = localPoint.normalized * DistanceFactor;
			float mag = _rb.velocity.magnitude;
			var newVelocity = new Vector3(normalizedLocal.x, normalizedLocal.y, -1) * mag;
			Vector3 oldVelocity = _rb.velocity;
			_rb.velocity = newVelocity;
			Debug.LogFormat("Velocity changed from {0} to {1}", oldVelocity, newVelocity);
		}
	}
}
