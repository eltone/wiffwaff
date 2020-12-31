using UnityEngine;


public class HumanPlayerController : PlayerController
{
    public Camera Camera;

    protected override void Start()
    {
        //Cursor.visible = false;
        base.Start();
    }

	void FixedUpdate()
    {
        var normVec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZAxisPos - Camera.transform.position.z);
        Vector3 mouse = Camera.ScreenToWorldPoint(normVec);
		MovePlayer(mouse);
	}
}
