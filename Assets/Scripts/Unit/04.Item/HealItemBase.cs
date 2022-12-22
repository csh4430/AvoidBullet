using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemBase : UnitBase
{
    private HealItemMove move;
    protected override void Awake()
    {
        base.Init();
        move = AddBehaviour<HealItemMove>();
        state.Stat.MaxHealth = 1000;
        state.Stat.Health = 1000;
        state.Stat.Spd = 5;
        AddBehaviour<UnitRender>();
        base.Awake();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_1") || other.CompareTag("Player_2"))
        {
            var player = other.gameObject.GetComponent<PlayerBase>();
            float hp = player.State.Stat.Health + 10;
            Mathf.Clamp(hp, 0, 100);
            player.State.Stat.Health = hp;
            move.ThisUnit.State.Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
