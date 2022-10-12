using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAttackState : CreatureBaseState
{
    public override void EnterState(CreatureStateManager creature)
    {
        Debug.Log("Attack EnterState");


    }
    public override void UpdateState(CreatureStateManager creature)
    {

    }
    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Attack PlAYER");
            collision.gameObject.GetComponent<PlayerController>().GetComponent<Rigidbody>().velocity = creature.transform.position * 100;
            collision.gameObject.GetComponent<PlayerController>().GetDamage(creature);
        }
    }
}
   

