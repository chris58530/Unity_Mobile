using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMoveState : CreatureBaseState
{
    public override void EnterState(CreatureStateManager creature)
    {
        Debug.Log("Enter EnterState");

    }
    public override void UpdateState(CreatureStateManager creature)
    {

    }
    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {

    }
}
