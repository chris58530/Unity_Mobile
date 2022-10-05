using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offSet;
    private void LateUpdate()
    {

        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z)+offSet;
    }
}
