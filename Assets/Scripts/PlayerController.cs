using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate()
    {
        var zAxixPos = -12.9f;
        var normVec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxixPos - Camera.main.transform.position.z);
        var mouse = Camera.main.ScreenToWorldPoint(normVec);
		rb.MovePosition(new Vector3(mouse.x, mouse.y, zAxixPos));
	}
}
