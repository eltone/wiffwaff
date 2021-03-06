﻿using UnityEngine;
using System.Collections;

// TODO: split this into multiple components for movement, collision effects, scoring etc
public class PlayerController : MonoBehaviour
{
	public Goal Goal;
	protected Rigidbody Rigidbody;
	private Collider _pc;
	private Vector3 _backWallSize;
	private Vector3 _playerSize;

    void Awake()
    {
		Goal.OnGoalScored += HandleGoalScored;
    }

    private void HandleGoalScored(string name)
    {
		Debug.Log(string.Format("Handle goal scored against player {0}", this.name));
    }

    protected virtual void Start()
    {
		var goalCollider = Goal.GetComponent<Collider>();
		_backWallSize = goalCollider.bounds.size;
		Rigidbody = GetComponent<Rigidbody>();
		_pc = GetComponent<Collider>();
		_playerSize = _pc.bounds.size;
		ZAxisPos = Rigidbody.transform.position.z;
    }

    protected float ZAxisPos;

	protected void MovePlayer(Vector3 target)
	{
		Rigidbody.MovePosition(ClampInsideBox(target, ZAxisPos));
	}

	public void Reset()
	{
		Rigidbody.velocity = Vector3.zero;
		Rigidbody.angularVelocity = Vector3.zero;
	}

	private Vector3 ClampInsideBox(Vector3 worldMouse, float zAxisPos)
	{
		Vector2 space = (_backWallSize - _playerSize)/ 2;
		return new Vector3(Mathf.Clamp(worldMouse.x, -space.x, space.x), Mathf.Clamp(worldMouse.y, -space.y, space.y), zAxisPos);
	}
}
