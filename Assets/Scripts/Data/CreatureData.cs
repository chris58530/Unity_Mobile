using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Creature Data",menuName ="ScriptableObject/Creat Creature Asset",order =1)]
public class CreatureData : ScriptableObject
{
    public float hp;
    public float moveSpeed;
    public float attack;
}
