using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateManager : MonoBehaviour
{
    public SlimeBaseState currentState;

    public SlimeIdleState idleState = new SlimeIdleState();
    public SlimeAttackState attackState = new SlimeAttackState();
    public SlimeDestroyState destroyState = new SlimeDestroyState();
    public SlimeMoveState moveState = new SlimeMoveState();
    public SlimeHurtState hurtState = new SlimeHurtState();

    public CreatureDataSO CreatureData;


    private void Start()    
    {
        currentState = idleState;

        currentState.EnterState(this);

        CreatureData.currentHP = CreatureData.maxHP;

    }
    private void FixedUpdate()
    {
        if(currentState == null)        
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

    public void SwitchState(SlimeBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}
