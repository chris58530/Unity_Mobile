using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PCowStateManager : MonoBehaviour
{
    public PCowBaseState currentState;
    public PCowAttackState attackState = new PCowAttackState();
    public PCowMoveState moveState = new PCowMoveState();
    public PCowChargeState chargeState = new PCowChargeState();

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
    private void OnTriggerEnter(Collider other)
    {
        if (currentState == null)
            currentState = moveState;
        else
            currentState.OnTriggerEnter(this, other);
    }
   

    public void SwitchState(PCowBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}