using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public PlayerController PlayerOne;
    public PlayerController PlayerTwo;
    public BallPhysics Ball;

    void Awake()
    {
        var players = FindObjectsOfType<PlayerController>();
        foreach (var player in players)
        {
            player.Goal.OnGoalScored += HandleGoalScored;
        }
        PlayerOne = players[0];
        PlayerTwo = players[1];
    }

    private void HandleGoalScored(string name)
    {
        Reset();
    }

    private void Reset()
    {
        PlayerOne.Reset();
        PlayerTwo.Reset();
        Ball.Reset();
    }
}
