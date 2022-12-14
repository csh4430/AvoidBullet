using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu
{
    public int Idx { get; set; }
    public StartSceneMgr StartSceneMgr { get; set; }
    public virtual void Interactive() {}
}
