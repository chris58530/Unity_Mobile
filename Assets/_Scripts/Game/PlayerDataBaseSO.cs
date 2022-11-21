using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Creature Data", menuName = "ScriptableObject/Creat Player Asset", order = 5)]

public class PlayerDataBaseSO : ScriptableObject
{
    public Player[] _player;

    public int PlayerCount
    {
        get { return _player.Length; }
    }
    public Player GetPlayer(Name name)
    {
        return _player[(int)name];
    }
    public Player GetPlayerByJson(int index)
    {
        return _player[index];
    }
    public enum Name
    {
       player_Cow,
       player_Octopus
    }
}
public class Player
{
    public string name;
    public GameObject playerObject;
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
    public GameObject[] items;
}
