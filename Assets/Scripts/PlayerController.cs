using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rb;
	public GameObject backWall;
	private Vector3 _backWallSize;
	private Vector3 _playerSize;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
		_backWallSize = backWall.GetComponent<Collider>().bounds.size;
		_playerSize = GetComponent<Collider>().bounds.size;
    }

	void FixedUpdate()
    {
        var zAxixPos = -12.9f;
        var normVec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxixPos - Camera.main.transform.position.z);
        Vector3 mouse = Camera.main.ScreenToWorldPoint(normVec);
		_rb.MovePosition(clampInsideBox(mouse, zAxixPos));
	}

	private Vector3 clampInsideBox(Vector3 worldMouse, float zAxisPos)
	{
		var space = (_backWallSize - _playerSize)/ 2;
		return new Vector3(Mathf.Clamp(worldMouse.x, -space.x, space.x), Mathf.Clamp(worldMouse.y, -space.y, space.y), zAxisPos);
	}
}
