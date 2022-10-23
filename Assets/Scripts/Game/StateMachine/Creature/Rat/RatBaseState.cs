using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class RatBaseState 
{
    public virtual void EnterState(RatStateManager creature)
    {
        Debug.Log(string.Format("<color=#fff000>{0}</color>", creature.currentState + "¼Ò¦¡"));
    }
    public abstract void UpdateState(RatStateManager creature);
    public virtual void OnCollisionEnter(RatStateManager creature, Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            creature.SwitchState(creature.attackState);
    }
}
#region NChicken: Idle Move Attack Hurt Destroy
public class RatIdleState : RatBaseState
{
    public override void UpdateState(RatStateManager creature)
    {
        throw new System.NotImplementedException();
    }
}

public class RatMoveState : RatBaseState
{
    Transform playerTrans;
    Rigidbody rb;


    public override void EnterState(RatStateManager creature)
    {
        base.EnterState(creature);
        rb = creature.GetComponent<Rigidbody>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public override void UpdateState(RatStateManager creature)
    {
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
    public override void OnCollisionEnter(RatStateManager creature, Collision collision)
    {
        base.OnCollisionEnter(creature, collision);

        //creature.CreatureData.hp -= collision.gameObject.GetComponent<CreatureDataSO>().attack;

        if (creature.CreatureData.currentHP < 0)
            creature.SwitchState(creature.moveState);
        else
            creature.SwitchState(creature.hurtState);
    }
}

public class RatAttackState : RatBaseState
{
    public override void EnterState(RatStateManager creature)
    {
        base.EnterState(creature);

        //GameObject.FindObjectOfType<PlayerController>().GetDamage(creature.transform);
        creature.SwitchState(creature.moveState);
    }
    public override void UpdateState(RatStateManager creature)
    {
        throw new System.NotImplementedException();
    }
}


public class RatHurtState : RatBaseState
{
    float hurtCD;
    public override void EnterState(RatStateManager creature)
    {
        base.EnterState(creature);
    }
    public override void UpdateState(RatStateManager creature)
    {
        if (hurtCD > 0)
            hurtCD -= Time.deltaTime;
        else
            creature.SwitchState(creature.moveState);
    }
}

#endregion
