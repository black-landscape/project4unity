//-------------------------------------------------------------------------------------
//	DashStandState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashStandState : HeroineDashState
{
    public override void ActiveState() { }

    public override void FixedUpdate()
    {
        if (InputUtil.touchOnce())
        {
            this.heroineDash.ChangeState(DashStateConst.DashRunState);
        }
    }
}
