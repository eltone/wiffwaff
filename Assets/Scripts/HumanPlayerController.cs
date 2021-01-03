using UnityEngine;
using MLAPI;


public class HumanPlayerController : PlayerController
{
    public Camera Camera;
    private bool _isLocalPlayer;
    private bool _hasFocus;

    protected override void Start()
    {
        //Cursor.visible = false;
        base.Start();
        _isLocalPlayer = GetComponentInParent<NetworkedObject>().IsLocalPlayer;
        _hasFocus = Application.isFocused;
    }

	void FixedUpdate()
    {
        if (!_hasFocus || !_isLocalPlayer)
            return;
        var zDistance = Mathf.Abs(ZAxisPos - Camera.transform.position.z);
        var normVec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance);
        Vector3 mouse = Camera.ScreenToWorldPoint(normVec);
		MovePlayer(mouse);
	}

    void OnApplicationFocus(bool hasFocus)
    {
        Debug.Log($"Focused: {hasFocus}");
        _hasFocus = hasFocus;
    }

    void OnApplicationPaused(bool isPaused)
    {
        Debug.Log($"Paused: {isPaused}");
        _hasFocus = !isPaused;
    }
}
