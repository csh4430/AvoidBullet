using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitRender : UnitBehaviour
{
    private UnitState state => ThisUnit.State;
    private Material mainMaterial;
    private Material outlineMaterial;
    private Light light;
    private Color originalColor;
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
    }

    public override void Update()
    {
        base.Update();
        LightUnit();
    }

    private void LightUnit()
    {
        var percentage = state.Stat.Health / state.Stat.MaxHealth;
        outlineMaterial.color = originalColor * percentage;
        light.intensity = percentage;
    }
}
