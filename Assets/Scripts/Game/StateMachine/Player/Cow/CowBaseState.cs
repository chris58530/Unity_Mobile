using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CowBaseState
{
    public Rigidbody rb;

    public virtual void EnterState(CowStateManager creature)
    {
        Debug.Log(string.Format("<color=#f5f500>{0}</color>", creature.currentState + "¼Ò¦¡"));
        rb = creature.GetComponent<Rigidbody>();
    }
    public virtual void UpdateState(CowStateManager creature)
    {


        if (!Input.anyKey && creature.CreatureData.currentAttackCD <= 0)
            creature.SwitchState(creature.attackState);
        else
            creature.SwitchState(creature.moveState);

      


        if (creature.CreatureData.currentAttackCD > 0)
            creature.CreatureData.currentAttackCD -= Time.deltaTime;

        if (creature.CreatureData.currentHurtCD > 0)
            creature.CreatureData.currentHurtCD -= Time.deltaTime;


    }

    public virtual void OnCollisionEnter(CowStateManager creature, Collision collision)
    {
        if (collision.gameObject.tag == ("EnemyAttack") && creature.CreatureData.currentHurtCD <= 0)
        {
            Debug.Log("EnemyAttack!!!");

            Vector3 forcePos = new Vector3(creature.transform.position.x - collision.transform.position.x, 0, creature.transform.position.z - collision.transform.position.z);
            rb.AddForce(forcePos.normalized * 50 * 100);
            creature.SwitchState(creature.hurtState);
        }
    }
}
#region Player_Cow: Idle Move Attack Hurt Destroy


public class CowIdleState : CowBaseState
{
    public override void EnterState(CowStateManager creature)
    {
        base.EnterState(creature);

    }
    public override void UpdateState(CowStateManager creature)
    {
        //animation here
        base.UpdateState(creature);
    }
}
public class CowAttackState : CowBaseState
{
    public override void EnterState(CowStateManager creature)
    {
        base.EnterState(creature);

    }
    public override void UpdateState(CowStateManager creature)
    {
        //animation here
        base.UpdateState(creature);
    }
}
public class CowMoveState : CowBaseState
{
    public override void EnterState(CowStateManager creature)
    {
        base.EnterState(creature);

    }
    public override void UpdateState(CowStateManager creature)
    {
        //animation here
        base.UpdateState(creature);
    }
}
public class CowHurtState : CowBaseState
{
    public override void EnterState(CowStateManager creature)
    {
        base.EnterState(creature);
    }
    public override void UpdateState(CowStateManager creature)
    {
        base.UpdateState(creature);
    }
}
#endregion
