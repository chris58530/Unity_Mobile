using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusStateManager : MonoBehaviour
{

    public OctopusBaseState currentState; //DEBUG 使用 正式版需改為PRIVATE!!!!!!

    public OctopusAttackState attackState = new OctopusAttackState();
    public OctopusDestroyState destroyState = new OctopusDestroyState();
    public OctopusHurtState hurtState = new OctopusHurtState();
    public OctopusMoveState moveState = new OctopusMoveState();
    public OctopusIdleState idleState = new OctopusIdleState();

    public CreatureDataSO CreatureData;

    public FixedJoystick fixedJoystick;
    private void Start()
    {
        currentState = idleState;
        CreatureData.currentAttackCD = CreatureData.attackCD;

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
