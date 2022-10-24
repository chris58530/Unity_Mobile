using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusAttack : MonoBehaviour
{
    public void Attack()
    {
        Debug.Log("PlayerAttack!");
        gameObject.GetComponentInChildren<CapsuleCollider>().enabled = true;
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
        StartCoroutine(Enabled());
        //³]¸m°ÊµeEvent
    }
    IEnumerator Enabled()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("PlayerDontAttack!");

        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        gameObject.GetComponentInChildren<CapsuleCollider>().enabled = false;

    }

}
