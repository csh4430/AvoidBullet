using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitRender : UnitBehaviour
{
    public GameObject DeathParticle { get; set; }
    
    protected UnitState state => ThisUnit.State;
    protected Material mainMaterial;
    protected Material outlineMaterial;
    protected Light light;
    protected Color originalColor;
    protected Color originalLight;

    protected bool isInCoroutine = false;
    protected bool isDead = false;
    public override void Awake()
    {
        base.Awake();
        mainMaterial = ThisUnit.transform.Find("Model").GetComponent<MeshRenderer>().material;
        outlineMaterial = ThisUnit.transform.Find("Model/Outline").GetComponent<MeshRenderer>().material;
        light = ThisUnit.transform.Find("Model/Light").GetComponent<Light>();
        originalColor = outlineMaterial.color;  
        originalLight = light.color;
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
        ThisUnit.StartCoroutine(SwitchColorCoroutine(originalColor, originalLight, percentage, Color.white, Color.white, 0.3f, 0.2f,
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
    IEnumerator SwitchColorCoroutine(Color originalColor, Color originalLight, float alpha1, Color nextColor, Color nextLight, float alpha2, float time, Action callback = null)
    {
        SetColor(nextColor, nextLight, alpha2);
        yield return new WaitForSeconds(time);
        SetColor(originalColor, originalLight, alpha1);
        callback?.Invoke();
    }
    
    public void SetColor(Color color, Color lightColor, float alpha)
    {
        color.a = alpha;
        outlineMaterial.color = color;
        outlineMaterial.SetFloat("_Alpha", alpha);
        light.color = lightColor;
        light.intensity = alpha;    
    }
}
