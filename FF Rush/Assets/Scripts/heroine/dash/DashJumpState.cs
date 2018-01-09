//-------------------------------------------------------------------------------------
//	DashJumpState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashJumpState : HeroineBaseState
{
    public override void ActiveState()
    {
        this._heroine.rgbody2D.AddForce(Vector2.up * GameConst.RUNNING_JUMP_GAP);
        this._heroine.rgbody2D.gravityScale = GameConst.RUNNING_JUMP_GRAVITY;
    }

    public override void FixedUpdate()
    {
        this._heroine.rgbody2D.gravityScale = GameConst.RUNNING_NORMAL_GRAVITY;
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            this._heroine.stateName = DashStateConst.DashRunState;
        }
    }
}
