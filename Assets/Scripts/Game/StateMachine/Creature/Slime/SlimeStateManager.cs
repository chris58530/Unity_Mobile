using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateManager : MonoBehaviour
{
    public SlimeBaseState currentState;

    public SlimeMoveState moveState = new SlimeMoveState();
    public SlimeHurtState hurtState = new SlimeHurtState();

    public CreatureDataSO CreatureData;


    private void Start()    
    {
        currentState = moveState;

        currentState.EnterState(this);

        CreatureData.currentHP = CreatureData.maxHP;

    }
    private void FixedUpdate()
    {
        if(currentState == null)        
            currentState = moveState;
        else
            currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentState == null)
            currentState = moveState;
        else
            currentState.OnTriggerEnter(this, other);
    }

    public void SwitchState(SlimeBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}
