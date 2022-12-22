using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour
{
    public UnitBase ThisUnit { get; set; }
    public virtual void Awake(){}
    public virtual void Start(){}
    public virtual void OnEnable() {}
    public virtual void Update(){}
}
