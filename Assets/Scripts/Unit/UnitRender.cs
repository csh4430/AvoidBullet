using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitRender : UnitBehaviour
{
    public GameObject DeathParticle { get; set; }
    
    private UnitState state => ThisUnit.State;
    private Material mainMaterial;
    private Material outlineMaterial;
    private Light light;
    private Color originalColor;

    private bool isInCoroutine = false;
    private bool isDead = false;
    public override void Awake()
    {
        base.Awake();
        mainMaterial = ThisUnit.transform.Find("Model").GetComponent<MeshRenderer>().material;
        outlineMaterial = ThisUnit.transform.Find("Model/Outline").GetComponent<MeshRenderer>().material;
        light = ThisUnit.transform.Find("Model/Light").GetComponent<Light>();
        originalColor = outlineMaterial.color;  
    }

    public override void Start()
    {
        base.Start();
        //GameManager.Instance.GetManager<PoolManager>().CreatePool(DeathParticle, 5);
    }

    public override void Update()
    {
        base.Update();
        if(state.NowState.HasFlag(StateEnum.Damage) && isInCoroutine is false)
            Damage();
        if(state.NowState.HasFlag(StateEnum.Death) && isDead is false)
            Die();
    }
    public void Damage()
    {

        isInCoroutine = true;
        float percentage = state.Stat.Health / state.Stat.MaxHealth;
        ThisUnit.StartCoroutine(SwitchColorCoroutine(originalColor, percentage, Color.white, 0.3f, 0.2f,
            () =>
            {
                isInCoroutine = false;
                state.RemoveState(StateEnum.Damage);
            }));
    }

    public void Die()
    {
        isDead = true;
        GameManager.Instance.GetManager<PoolManager>().EnqueueObject(ThisUnit.gameObject);

    }
    IEnumerator SwitchColorCoroutine(Color original, float alpha1, Color next, float alpha2, float time, Action callback = null)
    {
        SetColor(next, alpha2);
        yield return new WaitForSeconds(time);
        SetColor(original, alpha1);
        callback?.Invoke();
    }
    
    private void SetColor(Color color, float alpha)

    {
        color.a = alpha;
        outlineMaterial.color = color;
        outlineMaterial.SetFloat("_Alpha", alpha);
        light.color = color;
        light.intensity = alpha;    
    }
}
