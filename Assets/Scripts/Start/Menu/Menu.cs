using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu
{
    public bool IsOpen { get; protected set; }
    public StartSceneMgr StartSceneMgr { get; set; }
    public virtual void Interactive() {}
    public virtual void Deinteractive() {}
    public virtual void Awake(){}
    public virtual void Update(){}
}
