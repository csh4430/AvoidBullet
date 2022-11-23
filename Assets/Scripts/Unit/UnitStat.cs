using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitStat
{
    [field: SerializeField]
    public float MaxHealth { get; set; }
    [field: SerializeField]
    public float Health { get; set; }
    [field: SerializeField]
    public float Atk { get; set; }
    [field: SerializeField]
    public float Def { get; set; }
    [field: SerializeField]
    public float Spd { get; set; }
    [field: SerializeField]
    public float Critical { get; set; }
}
