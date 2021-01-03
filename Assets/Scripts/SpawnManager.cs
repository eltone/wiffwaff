using UnityEngine;
using MLAPI;
using System;

public class SpawnManager : NetworkedBehaviour
{
    public Transform PlayerOneSpawn;
    public Transform PlayerTwoSpawn;
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.IsHost)
        {
            NetworkingManager.Singleton.ConnectionApprovalCallback += ApprovalCallback;
            NetworkingManager.Singleton.StartHost(PlayerOneSpawn.position, PlayerOneSpawn.rotation);
        }
        else
        {
            NetworkingManager.Singleton.StartClient();
        }
        //NetworkingManager.Singleton.OnClientConnectedCallback += SpawnPlayer;
    }

    public override void NetworkStart()
    {
        Debug.Log("Network started!");
    }

    private void SpawnPlayer(ulong client)
    {
        Debug.Log($"Spawning client {client}");
        GameObject go;
        if (IsLocalPlayer)
        {
            go = Instantiate(playerPrefab, PlayerOneSpawn.position, PlayerOneSpawn.rotation);
        }
        else
        {
            go = Instantiate(playerPrefab, PlayerTwoSpawn.position, PlayerTwoSpawn.rotation);
        }
        go.GetComponent<NetworkedObject>().SpawnAsPlayerObject(client);
    }

    private void ApprovalCallback(byte[] connData, ulong clientId, NetworkingManager.ConnectionApprovedDelegate callback)
    {
        Debug.Log($"Handling approval for {clientId}");
        callback.Invoke(true, null, true, PlayerTwoSpawn.position, PlayerTwoSpawn.rotation);
    }
}
