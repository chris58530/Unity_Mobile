using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureIdleState : CreatureBaseState
{
    public float RamdomTime = 2;
    public override void EnterState(CreatureStateManager creature)
    {
        Debug.Log("Idle EnterState");
    }
    public override void UpdateState(CreatureStateManager creature)
    {
        Debug.Log("Idle UpdateState");
        Debug.Log(RamdomTime);
        RamdomTime -=Time.deltaTime;

        if (RamdomTime <= 0)
        {
            creature.SwitchState(creature.moveState);
        }
     

    }
    public override void OnCollisionEnter(CreatureStateManager creature, Collision collision)
    {

    }
}
