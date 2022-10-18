using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusStateManager : MonoBehaviour
{
    public OctopusBaseState currentState;
    public OctopusAttackState attackState = new OctopusAttackState();
    public OctopusDestroyState destroyState = new OctopusDestroyState();
    public OctopusHurtState hurtState = new OctopusHurtState();
    public OctopusMoveState moveState = new OctopusMoveState();
    public OctopusIdleState idleState = new OctopusIdleState();

    public CreatureDataSO CreatureData;


    private void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }
    private void FixedUpdate()
    {
        if (currentState == null)
            currentState = idleState;
        else
            currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentState == null)
            currentState = idleState;
        else
            currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(OctopusBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}
