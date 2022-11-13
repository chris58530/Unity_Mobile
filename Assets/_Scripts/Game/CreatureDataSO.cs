using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Creature Data",menuName ="ScriptableObject/Creat Creature Asset",order =1)]
public class CreatureDataSO : ScriptableObject
{

    [Header("���ʳt��")]
    public float moveSpeed;

    [Header("�����O")]
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
    private GameObject[] items;
    public GameObject dropItems
    {
        get => items[Random.Range(0, items.Length)]; 
    }

}
