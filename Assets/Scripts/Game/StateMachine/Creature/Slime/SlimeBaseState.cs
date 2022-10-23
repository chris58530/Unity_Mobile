using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlimeBaseState 
{
    public virtual void EnterState(SlimeStateManager creature)
    {
        Debug.Log(string.Format("<color=#ff0000>{0}</color>", creature.currentState + "¼Ò¦¡"));
    }
    public abstract void UpdateState(SlimeStateManager creature);
    public virtual void OnTriggerEnter(SlimeStateManager creature, Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            float damage = other.gameObject.GetComponentInParent<PlayerData>().attack;
            creature.CreatureData.currentHP -= damage;
            creature.SwitchState(creature.hurtState);
        }
    }
}
#region SlimeState:  Move  Hurt 




public class SlimeMoveState : SlimeBaseState
{
    Transform playerTrans;
    Rigidbody rb;


    public override void EnterState(SlimeStateManager creature)
    {
       base.EnterState(creature);
        rb = creature.GetComponent<Rigidbody>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void UpdateState(SlimeStateManager creature)
    {
        if (playerTrans != null)
        {
            rb.transform.LookAt(new Vector3(playerTrans.position.x, creature.transform.position.y, playerTrans.position.z));
            rb.transform.Translate(new Vector3(0, 0, 1* creature.CreatureData.moveSpeed * Time.deltaTime));
        }
     
    }
    public override void OnTriggerEnter(SlimeStateManager creature, Collider other)
    {
        base.OnTriggerEnter(creature, other);
    }
}

public class SlimeHurtState : SlimeBaseState
{
    public override void EnterState(SlimeStateManager creature)
    {
        if (creature.CreatureData.currentHP <= 0)
            GameObject.Destroy(creature.gameObject);
        base.EnterState(creature);
        creature.CreatureData.currentHurtCD = creature.CreatureData.hurtCD;
    }
    public override void UpdateState(SlimeStateManager creature)
    {
        if (creature.CreatureData.currentHurtCD > 0)
            creature.CreatureData.currentHurtCD -= Time.deltaTime;
        else
            creature.SwitchState(creature.moveState);
    }
}

#endregion