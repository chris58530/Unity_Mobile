using System.Collections;
using UnityEngine;

public abstract class CreatureBaseState
{
    public abstract void EnterState(CreatureStateManager creature);
    public abstract void UpdateState(CreatureStateManager creature);
    public abstract void OnCollisionEnter(CreatureStateManager creature,Collision collision);
    public virtual float RamdomTime
    {
        get { return Random.Range(0, 2);}   
    }

}
