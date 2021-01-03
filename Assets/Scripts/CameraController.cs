using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class CameraController : MonoBehaviour
{
    public Collider Goal;

    void Start()
    {
        var camera = GetComponent<Camera>();

        if (IsRemoteCamera())
        {
            camera.GetComponent<AudioListener>().enabled = false;
            camera.enabled = false;
        }
        else
        {
            var frustumHeight = Goal.bounds.size.y;
            var distance = frustumHeight * 0.5f / Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
            var localPosition = camera.transform.localPosition;
            var newPosition = new Vector3(localPosition.x, localPosition.y, -distance);
            camera.transform.localPosition = newPosition;
        }
    }

    private bool IsRemoteCamera()
    {
        return !GetComponentInParent<NetworkedObject>().IsLocalPlayer;
    }
}
