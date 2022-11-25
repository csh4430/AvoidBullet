using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public enum AttackType
{
    Circle,
    
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackType = AttackType.Circle;
            Attack();
        }
    }

    public override void Attack()
    { 
        ThisUnit.StartCoroutine(CircleAttack(sphereBullet, 50, 1, 0.001f, 5));
    }

    //divide circle into n parts and shoot n bullets
    IEnumerator CircleAttack(GameObject prefab, int n, float radius, float delay, int times)
    {
        int tmp = n;
        for (var t = 0; t < times; t++)
        {
            n = t % 2 == 0 ? tmp - 10 : tmp;
            for (var i = 0; i < n; i++)
            {
                var angle = i * Mathf.PI * 2 / n;
                var pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
                var bullet = GameManager.Instance.GetManager<PoolManager>().ReuseObject(prefab, ThisUnit.transform.position + pos, Quaternion.identity);
                bullet.GetComponent<BulletBase>().SetBulletDir(pos);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
