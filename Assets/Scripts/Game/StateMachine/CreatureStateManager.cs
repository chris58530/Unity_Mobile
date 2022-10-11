using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStateManager : MonoBehaviour
{
    CreatureBaseState currentState;    

    CreatureIdleState idleState =new CreatureIdleState();    
    CreatureAttackState attackState =new CreatureAttackState();
    CreatureHurtState hurtState =new CreatureHurtState();    
    CreatureMoveState moveState =new CreatureMoveState();
    private void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this,collision);
    }

    public void SwitchState(CreatureBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}
