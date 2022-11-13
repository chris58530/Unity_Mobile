using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Creature Data",menuName ="ScriptableObject/Creat Creature Asset",order =1)]
public class CreatureDataSO : ScriptableObject
{

    [Header("移動速度")]
    public float moveSpeed;

    [Header("攻擊力")]
    public float attackPower;



    [Header("攻擊冷卻")]
    public float attackCD;
    public float currentAttackCD;

    [Header("受傷冷卻")]
    public float hurtCD;
    public float currentHurtCD;

    [Header("血量設定")] 
    public float maxHP;
    public float currentHP;

    [Header("掉落物(隨機取一)")]
    [SerializeField]
    private GameObject[] items;
    public GameObject dropItems
    {
        get => items[Random.Range(0, items.Length)]; 
    }

}
