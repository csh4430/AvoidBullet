using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : UnitMove
{
    InputFlags inputFlags => ThisUnit.GetBehaviour<PlayerInput>().inputFlags;
    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void Translate()
    {
        var dir = Vector3.zero;
        int player = ThisUnit.gameObject.GetComponent<PlayerBase>().IsFirstPlayer ? 1 : -1;
        if (inputFlags.HasFlag(InputFlags.UpMove))
        {
            if (ThisUnit.transform.position.z * player > 19f)
                return;
            dir += Vector3.forward;
        }
        if (inputFlags.HasFlag(InputFlags.DownMove))
        {
            if (ThisUnit.transform.position.z * player < -19f)
                return;
            dir += Vector3.back;
        }
        if (inputFlags.HasFlag(InputFlags.LeftMove))
        {
            if (ThisUnit.transform.position.x * player < -19f )
                return;
            dir += Vector3.left;
        }
        if (inputFlags.HasFlag(InputFlags.RightMove))
        {
            if (ThisUnit.transform.position.x * player > 19f)
                return;
            dir += Vector3.right;
        }

        dir = dir.normalized;
        var nextDir = dir * (Time.deltaTime * Speed);
        if (GameManager.Instance.GetManager<MapManager>().CheckMap(ThisUnit.transform.position + nextDir) is false)
            return;
        ThisUnit.transform.Translate(nextDir, Space.Self);
    }
}
