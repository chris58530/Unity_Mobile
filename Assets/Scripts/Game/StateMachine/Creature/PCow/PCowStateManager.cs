using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCowStateManager : MonoBehaviour
{
    public PCowBaseState currentState;
    public PCowAttackState attackState = new PCowAttackState();
    public PCowDestroyState destroyState = new PCowDestroyState();
    public PCowHurtState hurtState = new PCowHurtState();
    public PCowMoveState moveState = new PCowMoveState();
    public PCowIdleState idleState = new PCowIdleState();

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

    public void SwitchState(PCowBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}
