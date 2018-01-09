//-------------------------------------------------------------------------------------
//	StandState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HeroineRunState : HeroineBaseState
{
    public override void ActiveState() { }

    public override void HandleInput()
    {
        this._heroine.rgbody2D.gravityScale = GameConst.RUNNING_NORMAL_GRAVITY;
        this._heroine.rgbody2D.velocity = new Vector2(GameConst.RUNNING_NORMAL_SPEED, this._heroine.rgbody2D.velocity.y);

        if (((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space)))
        {
            this._heroine.heroStateName = HeroineStateConst.HeroineJumpState;
        }
    }
}
