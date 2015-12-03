using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	void Update()
    {
        var zAxixPos = -12.9f;
        var normVec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxixPos - Camera.main.transform.position.z);
        var mouse = Camera.main.ScreenToWorldPoint(normVec);
		transform.localPosition = new Vector3(mouse.x, mouse.y, zAxixPos);
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
}
