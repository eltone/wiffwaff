using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public GameObject LeftWall;
	public GameObject BottomWall;
	private Rigidbody _rb;
	private Collider _pc;
	private Vector3 _backWallSize;
	private Vector3 _playerSize;

    void Start()
    {
		var leftHeight = LeftWall.GetComponent<Renderer>().bounds.size.y;
		var bottomWidth = BottomWall.GetComponent<Renderer>().bounds.size.x;
		_backWallSize = new Vector3(bottomWidth, leftHeight, 0);
		_rb = GetComponent<Rigidbody>();
		_pc = GetComponent<Collider>();
		_playerSize = _pc.bounds.size;
		ZAxisPos = _rb.transform.position.z;
    }

    protected float ZAxisPos;

	protected void MovePlayer(Vector3 target)
	{
		_rb.MovePosition(clampInsideBox(target, ZAxisPos));
	}

	private Vector3 clampInsideBox(Vector3 worldMouse, float zAxisPos)
	{
		Vector2 space = (_backWallSize - _playerSize)/ 2;
		return new Vector3(Mathf.Clamp(worldMouse.x, -space.x, space.x), Mathf.Clamp(worldMouse.y, -space.y, space.y), zAxisPos);
	}
}
