//-------------------------------------------------------------------------------------
//	DashJumpState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashJumpState : HeroineDashState
{
    public override void ActiveState()
    {
        this.heroineDash.rgbody2D.AddForce(Vector2.up * this.heroineDash.jumpGap);
    }

    public override void FixedUpdate()
    {
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == GameTagConst.Ground)
        {
            this.heroineDash.ChangeState(DashStateConst.DashRunState);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == GameTagConst.PTriggerReverseGravity)
        {
            this.heroineDash.reverseGravity();
        }
    }
}
