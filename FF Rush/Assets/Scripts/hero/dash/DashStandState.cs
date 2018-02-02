//-------------------------------------------------------------------------------------
//	DashStandState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashStandState : HeroDashState
{
    public override void ActiveState() { }

    public override void FixedUpdate()
    {
        if (InputUtil.touchOnce())
        {
            this.heroDash.ChangeState(DashStateConst.DashRunState);
        }
    }
}
