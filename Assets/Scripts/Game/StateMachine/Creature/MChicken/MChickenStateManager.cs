using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MChickenStateManager : MonoBehaviour
{
    public MChickenBaseState currentState;
    public MChickenAttackState attackState = new MChickenAttackState();
    public MChickenDestroyState destroyState = new MChickenDestroyState();    
    public MChickenHurtState hurtState = new MChickenHurtState();
    public MChickenMoveState moveState = new MChickenMoveState();
    public MChickenIdleState idleState = new MChickenIdleState();

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

    public void SwitchState(MChickenBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}
