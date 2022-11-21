using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Creature Data",menuName ="ScriptableObject/Creat Creature Asset",order =1)]
public class CreatureDataBaseSO : ScriptableObject
{
    public Creature[] _creature;
   
    public int CreatureCoun
    {
        get { return _creature.Length; }
    }
    public Creature GetCreature(Name name)
    {
        return _creature[(int)name];    
    }
    public enum Name
    {
        slime,
        chicken,
        PCow,
        rat
    }
}
[System.Serializable]
public class Creature
{
    public string creatureName;
    [Header("���ʳt��")]
    public float moveSpeed;

    public float attackPower;



    [Header("�����N�o")]
    public float attackCD;
    public float currentAttackCD;

    [Header("���˧N�o")]
    public float hurtCD;
    public float currentHurtCD;

    [Header("��q�]�w")]
    public float maxHP;
    public float currentHP;

    [Header("������(�H�����@)")]
    [SerializeField]
    public GameObject[] items;
   
}