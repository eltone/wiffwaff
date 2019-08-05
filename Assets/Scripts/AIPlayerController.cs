using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerController : PlayerController
{
    public float MovementSpeed;
    public GameObject Ball;

    public void FixedUpdate()
    {
        Vector3 ballPos = Ball.transform.position;
        Vector3 playerPos = transform.position;
        Vector2 movement = Vector2.MoveTowards(playerPos, ballPos, MovementSpeed * Time.fixedDeltaTime);
        MovePlayer(movement);
    }
}
