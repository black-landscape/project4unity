//-------------------------------------------------------------------------------------
//	DashSlashState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashSlashState : HeroineDashState
{
    public override void ActiveState()
    {
        this.heroineDash.stateName = DashStateConst.DashRunState;
    }

    public override void FixedUpdate()
    {
    }
}
