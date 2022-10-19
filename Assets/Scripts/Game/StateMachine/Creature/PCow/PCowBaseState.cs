using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class PCowBaseState
{
    public virtual void EnterState(PCowStateManager creature)
    {
        Debug.Log(string.Format("<color=#ff0000>{0}</color>", creature.currentState + "¼Ò¦¡"));
    }
    public abstract void UpdateState(PCowStateManager creature);
    public virtual void OnCollisionEnter(PCowStateManager creature, Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            creature.SwitchState(creature.attackState);
        if (collision.gameObject.tag == "PlayerAttack")
            creature.SwitchState(creature.hurtState);
        else return;
    }
}
#region SlimeState: Idle Move Attack Hurt Destroy


public class PCowIdleState : PCowBaseState
{
    public override void EnterState(PCowStateManager creature)
    {

        base.EnterState(creature);
    }
    public override void UpdateState(PCowStateManager creature)
    {
        creature.SwitchState(creature.moveState);

    }
}
public class PCowMoveState : PCowBaseState
{
    Transform playerTrans;
    Rigidbody rb;


    public override void EnterState(PCowStateManager creature)
    {
        base.EnterState(creature);
        rb = creature.GetComponent<Rigidbody>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void UpdateState(PCowStateManager creature)
    {
        if (playerTrans != null)
        {
            rb.transform.LookAt(new Vector3(playerTrans.position.x, creature.transform.position.y, playerTrans.position.z));
            rb.transform.Translate(new Vector3(0, 0, 1 * creature.CreatureData.moveSpeed * Time.deltaTime));
        }
        else
        {
            Debug.Log("NO PlAYER");
            creature.SwitchState(creature.destroyState);

        }
    }
}

public class PCowAttackState : PCowBaseState
{
    public override void EnterState(PCowStateManager creature)
    {
        base.EnterState(creature);

        //GameObject.FindObjectOfType<PlayerController>().GetDamage(creature.transform);
        creature.SwitchState(creature.idleState);

    }

    public override void UpdateState(PCowStateManager creature)
    {
       
        throw new System.NotImplementedException();
    }
}



public class PCowHurtState : PCowBaseState
{
    public override void EnterState(PCowStateManager creature)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PCowStateManager creature)
    {
        throw new System.NotImplementedException();
    }
}
public class PCowDestroyState : PCowBaseState
{
    public override void EnterState(PCowStateManager creature)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PCowStateManager creature)
    {
        throw new System.NotImplementedException();
    }
}
#endregion