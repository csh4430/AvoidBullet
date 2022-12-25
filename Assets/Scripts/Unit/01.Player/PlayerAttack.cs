using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : UnitAttack
{
    public GameObject projectilePrefab { get; set; } = null;
    InputFlags inputFlags => ThisUnit.GetBehaviour<PlayerInput>().inputFlags;
    private PoolManager poolMgr = null;
    public override void Awake()
    {
        base.Awake();   
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Item"))
        {
            ThisUnit.State.Stat.Health = Mathf.Min(ThisUnit.State.Stat.Health + 10, 100);
            other.gameObject.GetComponent<HealItemBase>()?.move.ThisUnit.State.Die();
        }
    }
    public override void Start()
    {
        base.Start();
        poolMgr = GameManager.Instance.GetManager<PoolManager>();
        poolMgr.CreatePool(projectilePrefab, 5);
        ThisUnit.StartCoroutine(AutoAttack());
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Attack()
    {

    }
    private IEnumerator AutoAttack()
    {
        while (true)
        {
            var bulletObj = poolMgr.ReuseObject(projectilePrefab, ThisUnit.transform);
            bulletObj.transform.SetParent(null);
            var bullet = bulletObj.GetComponent<BulletBase>();
            bullet.Damage = ThisUnit.State.Stat.Atk;
            yield return new WaitForSeconds(0.4f);
        }
    }
}
