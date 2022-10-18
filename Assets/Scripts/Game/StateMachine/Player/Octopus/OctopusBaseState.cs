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
       if(Input.touchCount ==0 && creature.CreatureData.currentAttackCD <= 0)
            creature.SwitchState(creature.attackState);
        else
            creature.SwitchState(creature.moveState);


        if (creature.CreatureData.currentAttackCD > 0 )
        {
            creature.CreatureData.currentAttackCD -= Time.deltaTime;
        }
        
    }

    public virtual void OnCollisionEnter(OctopusStateManager creature, Collision collision)
    {
        if (collision.gameObject.tag == ("EnemyAttack"))
            creature.SwitchState(creature.hurtState);
    }
}
#region Player_Octopus: Idle Move Attack Hurt Destroy


public class OctopusIdleState : OctopusBaseState
{
    public override void UpdateState(OctopusStateManager creature)
    {
        //animation here
        creature.SwitchState(creature.moveState);
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
    public override void OnCollisionEnter(OctopusStateManager creature, Collision collision)
    {
        base.OnCollisionEnter(creature, collision);

       
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
    public override void OnCollisionEnter(OctopusStateManager creature, Collision collision)
    {
        if (collision.gameObject.tag == ("EnemyAttack"))
        {
            Vector3 forcePos = new Vector3(creature.transform.position.x - collision.transform.position.x, 0, creature.transform.position.z - collision.transform.position.z);
            rb.AddForce(-forcePos.normalized * 20 * 100);
        }
      
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
