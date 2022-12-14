using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyBase : UnitBase
{
    [SerializeField] private GameObject deathEffect;
    public List<GameObject> Bullets = new List<GameObject>(4);

    protected override void Awake()
    {
        base.Init();
        state = AddBehaviour<UnitState>();
        AddBehaviour<UnitRender>().DeathParticle = deathEffect;
        state.Stat.MaxHealth = 200;
        state.Stat.Health = 200;
        state.Stat.Atk = 7;
        base.Awake();
    }
}
