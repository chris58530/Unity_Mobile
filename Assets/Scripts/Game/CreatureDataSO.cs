using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Creature Data",menuName ="ScriptableObject/Creat Creature Asset",order =1)]
public class CreatureDataSO : ScriptableObject
{
    public float hp;
    public float moveSpeed;
    public float attack;
    public GameObject dropItems;
    public float attackCD;
    public float currentAttackCD;
    public FixedJoystick joystick;

}
