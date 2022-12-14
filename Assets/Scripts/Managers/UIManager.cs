using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager
{
    private StayUIMgr stayUIMgr = null;

    public StayUIMgr StayUIMgr
    {
        get
        {
            if(stayUIMgr == null)
            {
                stayUIMgr = GameObject.Find("StayUIMgr").GetComponent<StayUIMgr>();
            }

            return stayUIMgr;
        }
    }
}
