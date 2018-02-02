//-------------------------------------------------------------------------------------
//	DashSlashState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashSlashState : HeroDashState
{
    public override void ActiveState()
    {
        this.heroDash.ChangeState(DashStateConst.DashRunState);
    }

    public override void FixedUpdate()
    {
    }
}
