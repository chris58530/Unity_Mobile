using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBae : MonoBehaviour
{
    Transform playerTrans;
    private void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        float dis = Vector3.Distance(playerTrans.position, transform.position);
        if (dis > 100)
        {
            Destroy(transform.gameObject);
        }
    }
}
