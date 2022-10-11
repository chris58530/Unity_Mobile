using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureIdleState : CreatureBaseState
{
    public override float RamdomTime => base.RamdomTime;
    public override void EnterState(CreatureStateManager creature)
    {
        Debug.Log("Enter IdleState");
        Debug.Log(RamdomTime);
    }
    public override void UpdateState(CreatureStateManager creature)
    {

    }
    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {

    }
}
