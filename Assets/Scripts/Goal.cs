using UnityEngine;

public class Goal : MonoBehaviour
{
    public event OnGoalScoredHandler OnGoalScored;

    public delegate void OnGoalScoredHandler(string name);

    void OnTriggerEnter(Collider collider)
    {
        // TODO: change score
        // TODO: check for game over
        // TODO: reset ball
        // TODO: reset players

        OnGoalScored(name);
    }
}
