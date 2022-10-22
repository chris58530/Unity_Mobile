using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class PCowBaseState
{
    protected Transform playerTrans;
    protected Rigidbody rb;
    public virtual void EnterState(PCowStateManager creature)
    {
        Debug.Log(string.Format("<color=#ff0000>{0}</color>", creature.currentState + "模式"));

        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public virtual void UpdateState(PCowStateManager creature)
    {
        float distance = Vector3.Distance(playerTrans.position, creature.transform.position);
        Debug.Log(distance);
        if (creature.CreatureData.currentAttackCD > 0)
        {
            creature.CreatureData.currentAttackCD -= Time.deltaTime;
        }
        else if(distance <= 5 && creature.CreatureData.currentAttackCD <= 0)
        {
            creature.SwitchState(creature.attackState);
        }
    }
    public virtual void OnCollisionEnter(PCowStateManager creature, Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            creature.SwitchState(creature.attackState);
        if (collision.gameObject.tag == "PlayerAttack")
            creature.SwitchState(creature.hurtState);
        else return;
    }
}
#region SlimeState:  Move Attack Hurt 



public class PCowMoveState : PCowBaseState
{


    public override void EnterState(PCowStateManager creature)
    {
        base.EnterState(creature);
        rb = creature.GetComponent<Rigidbody>();

    }

    public override void UpdateState(PCowStateManager creature)
    {
        base.UpdateState(creature);
        if (playerTrans != null)
        {
            rb.transform.LookAt(new Vector3(playerTrans.position.x, creature.transform.position.y, playerTrans.position.z));
            rb.transform.Translate(new Vector3(0, 0, 1 * creature.CreatureData.moveSpeed * Time.deltaTime));
        }
        else
        {
            Debug.Log("NO PlAYER");

        }
    }
}

public class PCowAttackState : PCowBaseState
{
    Vector3 target;
    float charge = 3; //續力時間

    float goToMove = -5; //
    public override void EnterState(PCowStateManager creature)
    {
        base.EnterState(creature);

        target = playerTrans.position;
        rb = creature.GetComponent<Rigidbody>();

        //GameObject.FindObjectOfType<PlayerController>().GetDamage(creature.transform);

    }

    public override void UpdateState(PCowStateManager creature)
    {
        charge -= Time.deltaTime;
        if (charge <= 0)
            creature.transform.position = Vector3.MoveTowards(creature.transform.position, target,creature.CreatureData.moveSpeed*3*Time.deltaTime);

        if (charge <= goToMove)
        {
            creature.SwitchState(creature.moveState);
            charge = 3;
        }
    }
}



public class PCowHurtState : PCowBaseState
{
    public override void EnterState(PCowStateManager creature)
    {
    }

    public override void UpdateState(PCowStateManager creature)
    {
    }
}

#endregion