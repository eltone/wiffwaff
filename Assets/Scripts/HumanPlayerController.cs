using UnityEngine;

public class HumanPlayerController : PlayerController
{
	void FixedUpdate()
    {
        var normVec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZAxisPos - Camera.main.transform.position.z);
        Vector3 mouse = Camera.main.ScreenToWorldPoint(normVec);
		MovePlayer(mouse);
	}
}
