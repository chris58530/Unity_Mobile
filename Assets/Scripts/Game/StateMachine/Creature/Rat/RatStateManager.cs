using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatStateManager : MonoBehaviour
{
    public RatBaseState currentState;
    public RatAttackState attackState = new RatAttackState();
    public RatHurtState hurtState = new RatHurtState();
    public RatMoveState moveState = new RatMoveState();

    public CreatureDataSO CreatureData;


    private void Start()
    {
        currentState = moveState;

        currentState.EnterState(this);

        CreatureData.currentHP = CreatureData.maxHP;

    }
    private void FixedUpdate()
    {
        if (currentState == null)
            currentState = moveState;
        else
            currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentState == null)
            currentState = moveState;
        else
            currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(RatBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}
