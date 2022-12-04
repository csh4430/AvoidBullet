using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public enum AttackType
{
    Circle,
    Wave,
    Sector,
    
}

public class EnemyAttack : UnitAttack
{
    AttackType attackType;

    public GameObject sphereBullet { get; set; } = null;
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
    }
    
    public override void Update()
    {
        base.Update();
    }

    public override void Attack()
    { 
        
    }
    
    protected void Attack(AttackType attackType, GameObject prefab, int n, float radius, float delay, int times, GameObject target = null, float angle = 0f)
    {
        this.attackType = attackType;
        switch (attackType)
        {
            case AttackType.Circle:
                ThisUnit.StartCoroutine(CircleAttack(prefab, n, radius, delay, times));
                break;
            case AttackType.Wave:
                ThisUnit.StartCoroutine(WaveAttack(prefab, n, radius, delay, times));
                break;
            case AttackType.Sector:
                ThisUnit.StartCoroutine(SectorAttack(prefab, target, n, radius, angle, delay, times));
                break;
        }
    }
    
    protected IEnumerator WaveAttack(GameObject prefab, int n, float radius, float delay, int times)
    {
        for (var t = 0; t < times; t++)
        {
            for (var i = 0; i < n; i++)
            {
                var angle = i * Mathf.PI * 2 / n;
                var pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
                var bulletObj = GameManager.Instance.GetManager<PoolManager>().ReuseObject(prefab, ThisUnit.transform.position + pos, Quaternion.identity); 
                var bullet = bulletObj.GetComponent<BulletBase>();
                bullet.SetBulletDir(pos);
                bullet.Damage = ThisUnit.State.Stat.Atk;
                yield return new WaitForSeconds(delay);
            }
        }
    }

    protected IEnumerator CircleAttack(GameObject prefab, int n, float radius, float delay, int times)
    {
        float offset;
        for (var t = 0; t < times; t++)
        {
            offset = t % 2 == 0 ? Mathf.PI / 4 : 0;
            for (var i = 0; i < n; i++)
            {
                var angle = (i * (Mathf.PI * 2) / n) + offset;
                var pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
                var bulletObj = GameManager.Instance.GetManager<PoolManager>().ReuseObject(prefab, ThisUnit.transform.position + pos, Quaternion.identity); 
                var bullet = bulletObj.GetComponent<BulletBase>();
                bullet.SetBulletDir(pos);
                bullet.Damage = ThisUnit.State.Stat.Atk;
            }
            yield return new WaitForSeconds(delay);
        }
    }
    protected IEnumerator SectorAttack(GameObject prefab, GameObject target, int n, float radius, float angle, float delay, int times)
    {
        for (var t = 0; t < times; t++)
        {
            var offset = n % 2 == 0 ? 0 : 0.5f;
            var pos = (Quaternion.Euler(0, angle / 2, 0) * (target.transform.position - ThisUnit.transform.position)).normalized;
            for (var i = 0; i < n; i++)
            {
                var dir = Quaternion.Euler(0, -angle * (i + offset) / n, 0) * pos * radius;
                var bulletObj = GameManager.Instance.GetManager<PoolManager>().ReuseObject(prefab, ThisUnit.transform.position + dir, Quaternion.identity); 
                var bullet = bulletObj.GetComponent<BulletBase>();
                bullet.SetBulletDir(dir);
                bullet.Damage = ThisUnit.State.Stat.Atk;
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
