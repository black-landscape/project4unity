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
        if (((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space)))
        {
            this.heroineDash.stateName = DashStateConst.DashRunState;
        }
    }
}
