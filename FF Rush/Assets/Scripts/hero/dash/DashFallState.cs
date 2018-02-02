//-------------------------------------------------------------------------------------
//	DashFallState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashFallState : HeroDashState
{
    public override void ActiveState()
    {
        this.heroDash.rgbody2D.AddForce(Vector2.down * this.heroDash.fallGap);
    }

    public override void FixedUpdate()
    {
        this.heroDash.rgbody2D.gravityScale = this.heroDash.gravity;
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == GameTagConst.Ground)
        {
            this.heroDash.ChangeState(DashStateConst.DashRunState);
        }
    }
}
