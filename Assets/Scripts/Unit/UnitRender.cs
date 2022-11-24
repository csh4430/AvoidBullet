using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRender : UnitBehaviour
{
    private UnitState state => ThisUnit.State;
    private Material mainMaterial;
    private Material outlineMaterial;
    private Light light;
    public override void Awake()
    {
        base.Awake();
        mainMaterial = ThisUnit.transform.Find("Model").GetComponent<MeshRenderer>().material;
        outlineMaterial = ThisUnit.transform.Find("Model/Outline").GetComponent<MeshRenderer>().material;
        light = ThisUnit.transform.Find("Model/Light").GetComponent<Light>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        LightUnit();
    }

    private void LightUnit()
    {
        var percentage = state.Stat.Health / state.Stat.MaxHealth;
        mainMaterial.color = Color.white * percentage;
        outlineMaterial.SetFloat("_Alpha", percentage);
        outlineMaterial.SetFloat("_Intensity", percentage * 2);
        light.intensity = percentage;
    }
}
