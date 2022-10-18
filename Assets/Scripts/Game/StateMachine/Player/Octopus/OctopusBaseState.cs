using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OctopusBaseState
{
    public virtual void EnterState(OctopusStateManager creature)
    {
        Debug.Log(string.Format("<color=#fff000>{0}</color>", creature.currentState + "模式"));
    }
    public abstract void UpdateState(OctopusStateManager creature);
    public virtual void OnCollisionEnter(OctopusStateManager creature, Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            creature.SwitchState(creature.attackState);
    }
}
#region NChicken: Idle Move Attack Hurt Destroy


public class OctopusIdleState : OctopusBaseState
{
    public override void UpdateState(OctopusStateManager creature)
    {
        base.EnterState(creature);
        creature.SwitchState(creature.moveState);
    }
}
public class OctopusMoveState : OctopusBaseState
{
    Transform playerTrans;
    Rigidbody rb;


    public override void EnterState(OctopusStateManager creature)
    {
        base.EnterState(creature);
        rb = creature.GetComponent<Rigidbody>();
        playerTrans = GameObject.Find("Player").transform;
    }

    public override void UpdateState(OctopusStateManager creature)
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
    public override void OnCollisionEnter(OctopusStateManager creature, Collision collision)
    {
        base.OnCollisionEnter(creature, collision);

        //creature.CreatureData.hp -= collision.gameObject.GetComponent<CreatureDataSO>().attack;

        if (creature.CreatureData.hp < 0)
            creature.SwitchState(creature.destroyState);
        else
            creature.SwitchState(creature.hurtState);
    }
}

public class OctopusAttackState : OctopusBaseState
{
    public override void EnterState(OctopusStateManager creature)
    {
        base.EnterState(creature);

        GameObject.FindObjectOfType<PlayerController>().GetDamage(creature.transform);
        creature.SwitchState(creature.idleState);
    }
    public override void UpdateState(OctopusStateManager creature)
    {
        throw new System.NotImplementedException();
    }
}


public class OctopusHurtState : OctopusBaseState
{
    float hurtCD;
    public override void EnterState(OctopusStateManager creature)
    {
        base.EnterState(creature);
        hurtCD = creature.CreatureData.attack;
    }
    public override void UpdateState(OctopusStateManager creature)
    {
        if (hurtCD > 0)
            hurtCD -= Time.deltaTime;
        else
            creature.SwitchState(creature.idleState);
    }
}
public class OctopusDestroyState : OctopusBaseState
{
    public override void EnterState(OctopusStateManager creature)
    {
        base.EnterState(creature);
        //噴掉落物
        //動畫
        GameObject.Destroy(creature.gameObject);
    }

    public override void UpdateState(OctopusStateManager creature)
    {
        throw new System.NotImplementedException();
    }
}
#endregion
