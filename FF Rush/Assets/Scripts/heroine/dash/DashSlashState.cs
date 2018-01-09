//-------------------------------------------------------------------------------------
//	DashSlashState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashSlashState : HeroineBaseState
{
    public override void ActiveState()
    {
        this._heroine.stateName = DashStateConst.DashRunState;
    }

    public override void FixedUpdate()
    {
    }
}
