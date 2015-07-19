using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	void Update() {
		var horiz = Input.GetAxis ("Mouse X");
		var vertical = Input.GetAxis ("Mouse Y");
		var vec = new Vector3 (horiz, 0, vertical);
		transform.Translate (vec);
	}
}
