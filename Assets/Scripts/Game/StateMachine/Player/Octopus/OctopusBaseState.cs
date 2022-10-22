using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OctopusBaseState
{
    public Rigidbody rb;

    public virtual void EnterState(OctopusStateManager creature)
    {
        Debug.Log(string.Format("<color=#f5f5dc>{0}</color>", creature.currentState + "模式"));
        rb = creature.GetComponent<Rigidbody>();
    }
    public virtual void UpdateState(OctopusStateManager creature)
    {


        if (!Input.anyKey && creature.CreatureData.currentAttackCD <= 0)
            creature.SwitchState(creature.attackState);
        else
            creature.SwitchState(creature.moveState);

        //if (Input.touchCount == 0 && creature.CreatureData.currentAttackCD <= 0)
        //    creature.SwitchState(creature.attackState);
        //else
        //    creature.SwitchState(creature.moveState);


        if (creature.CreatureData.currentAttackCD > 0)
            creature.CreatureData.currentAttackCD -= Time.deltaTime;

        if (creature.CreatureData.currentHurtCD > 0)
            creature.CreatureData.currentHurtCD -= Time.deltaTime;


    }

    public virtual void OnCollisionEnter(OctopusStateManager creature, Collision collision)
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
#region Player_Octopus: Idle Move Attack Hurt Destroy


public class OctopusIdleState : OctopusBaseState
{
    public override void EnterState(OctopusStateManager creature)
    {
        base.EnterState(creature);
        creature.SwitchState(creature.moveState);

    }
    public override void UpdateState(OctopusStateManager creature)
    {
        //animation here
        base.UpdateState(creature);
    }
}
public class OctopusMoveState : OctopusBaseState
{
    private FixedJoystick _joystick;

    public override void EnterState(OctopusStateManager creature)
    {
        base.EnterState(creature);
        _joystick = creature.fixedJoystick;
        rb = creature.gameObject.GetComponent<Rigidbody>();


    }

    public override void UpdateState(OctopusStateManager creature)
    {
        base.UpdateState(creature);
        rb.velocity = new Vector3(creature.fixedJoystick.Horizontal * creature.CreatureData.moveSpeed, rb.velocity.y, creature.fixedJoystick.Vertical * creature.CreatureData.moveSpeed);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            creature.transform.rotation = Quaternion.LookRotation(rb.velocity);           
        }
    }
    
}

public class OctopusAttackState : OctopusBaseState
{

    public override void EnterState(OctopusStateManager creature)
    {
        base.EnterState(creature);
    }
    public override void UpdateState(OctopusStateManager creature)
    {
        base.UpdateState(creature);
        if (creature.CreatureData.currentAttackCD <= 0)
        {
            OctopusAttack octopusAttack = creature.GetComponent<OctopusAttack>();
            octopusAttack.Attack();
            creature.CreatureData.currentAttackCD = creature.CreatureData.attackCD;
        }
    }    
}


public class OctopusHurtState : OctopusBaseState
{
    public override void EnterState(OctopusStateManager creature)
    {
        base.EnterState(creature);
        creature.CreatureData.currentHurtCD = creature.CreatureData.hurtCD;
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
