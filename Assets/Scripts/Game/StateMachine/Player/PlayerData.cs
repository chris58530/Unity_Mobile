using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    CreatureDataSO Data;

    public float attack { get { return Data.attackPower; }}
}
