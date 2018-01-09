//-------------------------------------------------------------------------------------
//	StandState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HeroineStandState : HeroineBaseState
{
    public override void ActiveState() { }

    public override void HandleInput()
    {
        if (((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space)))
        {
            this._heroine.heroStateName = HeroineStateConst.HeroineRunState;
        }
    }
}
