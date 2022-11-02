using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowStateManager : MonoBehaviour
{
    public CowBaseState currentState; //DEBUG �ϥ� �������ݧאּPRIVATE!!!!!!

    public CowIdleState idleState = new CowIdleState();
    public CowMoveState moveState = new CowMoveState();
    public CowAttackState attackState = new CowAttackState();
    public CowHurtState hurtState = new CowHurtState();

    public CreatureDataSO CreatureData;

    public FixedJoystick fixedJoystick;
    private Vector3 fixedJoystickPos;
    private void Start()
    {
        currentState = idleState;
        CreatureData.currentAttackCD = CreatureData.attackCD;

        currentState.EnterState(this);
        fixedJoystickPos = fixedJoystick.transform.position;

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

    public void SwitchState(CowBaseState creatureBaseState)
    {
        currentState = creatureBaseState;
        creatureBaseState.EnterState(this);
    }
}
