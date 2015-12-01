using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float sensitivity = 0.5f;

	void Update() {
		var horiz = Input.GetAxis ("Mouse X");
		var vertical = Input.GetAxis ("Mouse Y");
		var vec = new Vector3 (horiz*sensitivity, vertical*sensitivity);
		transform.Translate (vec);
	}
}
