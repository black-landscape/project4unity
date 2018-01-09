//-------------------------------------------------------------------------------------
//	JumpState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HeroineJumpState : HeroineBaseState
{
    public override void ActiveState()
    {
        this._heroine.rgbody2D.AddForce(Vector2.up * GameConst.RUNNING_JUMP_GAP);
        this._heroine.rgbody2D.gravityScale = GameConst.RUNNING_JUMP_GRAVITY;
    }

    public override void HandleInput()
    {
        this._heroine.rgbody2D.gravityScale = GameConst.RUNNING_NORMAL_GRAVITY;

    }
}
