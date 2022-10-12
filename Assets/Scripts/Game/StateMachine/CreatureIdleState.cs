using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureIdleState : CreatureBaseState
{
    public float RamdomTime;
    public override void EnterState(CreatureStateManager creature)
    {
        RamdomTime = Random.Range(2, 4);
        Debug.Log("Idle EnterState");
        Debug.Log(RamdomTime);

    }
    public override void UpdateState(CreatureStateManager creature)
    {
        Debug.Log("Idle UpdateState");
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
