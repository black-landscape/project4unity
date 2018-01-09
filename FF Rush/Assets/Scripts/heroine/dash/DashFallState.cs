//-------------------------------------------------------------------------------------
//	DashFallState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashFallState : HeroineDashState
{
    public override void ActiveState()
    {
        this.heroineDash.rgbody2D.AddForce(Vector2.down * this.heroineDash.fallGap);
    }

    public override void FixedUpdate()
    {
        this.heroineDash.rgbody2D.gravityScale = this.heroineDash.gravity;
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            this.heroineDash.stateName = DashStateConst.DashRunState;
        }
    }
}
