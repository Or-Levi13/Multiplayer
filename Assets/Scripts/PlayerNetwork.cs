using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{

    private NetworkVariable<int> randomNum = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Owner);
    private void Update()
    {
        Debug.Log(OwnerClientId + ": Random Number: " + randomNum.Value);
        if (!IsOwner) return;

        if (Input.GetKey(KeyCode.T))
        {
            randomNum.Value = Random.Range(0, 100);
        }
        Vector3 moveDir = new Vector3(0, 0, 0);
        float moveSpeed = 3f;

        if (Input.GetKey(KeyCode.W)) moveDir.z += 1f;
        if (Input.GetKey(KeyCode.S)) moveDir.z -= 1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x -= 1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x += 1f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
