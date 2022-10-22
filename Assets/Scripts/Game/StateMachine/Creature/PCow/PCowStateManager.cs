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
    }
    private void FixedUpdate()
    {
        if (currentState == null)
            currentState = moveState;
        else
            currentState.UpdateState(this);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (currentState == null)
            currentState = moveState;
        else
            currentState.OnTriggerEnter(this, collision);
    }
   

    public void SwitchState(PCowBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}
