using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MChickenBaseState
{
    public virtual void EnterState(MChickenStateManager creature)
    {
        Debug.Log(string.Format("<color=#fff000>{0}</color>", creature.currentState + "¼Ò¦¡"));
    }
    public abstract void UpdateState(MChickenStateManager creature);
    public virtual void OnCollisionEnter(MChickenStateManager creature, Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            creature.SwitchState(creature.attackState);
        if (collision.gameObject.tag == "PlayerAttack")
            creature.SwitchState(creature.hurtState);
        else return;
    }
}
#region NChicken: Idle Move Attack Hurt Destroy


public class MChickenIdleState : MChickenBaseState
{
    public override void UpdateState(MChickenStateManager creature)
    {
        base.EnterState(creature);
        creature.SwitchState(creature.moveState);   
    }
}
public class MChickenMoveState : MChickenBaseState
{
    Transform playerTrans;
    Rigidbody rb;


    public override void EnterState(MChickenStateManager creature)
    {
        base.EnterState(creature);
        rb = creature.GetComponent<Rigidbody>();
        playerTrans = GameObject.Find("Player").transform;
    }

    public override void UpdateState(MChickenStateManager creature)
    {
        if (playerTrans != null)
        {
            rb.transform.LookAt(new Vector3(playerTrans.position.x, creature.transform.position.y, playerTrans.position.z));
            rb.transform.Translate(new Vector3(0, 0, 1 * creature.MChickenData.moveSpeed * Time.deltaTime));
        }
        else
        {
            Debug.Log("NO PlAYER");
            creature.SwitchState(creature.destroyState);

        }
    }
}

public class MChickenAttackState : MChickenBaseState
{
    public override void EnterState(MChickenStateManager creature)
    {
        base.EnterState(creature);

        GameObject.FindObjectOfType<PlayerController>().GetDamage(creature.transform);
        creature.SwitchState(creature.idleState);
    }
    public override void UpdateState(MChickenStateManager creature)
    {
        throw new System.NotImplementedException();
    }
}


public class MChickenHurtState : MChickenBaseState
{
    public override void UpdateState(MChickenStateManager creature)
    {
        throw new System.NotImplementedException();
    }
}
public class MChickenDestroyState : MChickenBaseState
{
    public override void UpdateState(MChickenStateManager creature)
    {
        throw new System.NotImplementedException();
    }
}
#endregion
