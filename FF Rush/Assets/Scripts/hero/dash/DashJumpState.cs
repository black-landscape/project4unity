//-------------------------------------------------------------------------------------
//	DashJumpState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashJumpState : HeroDashState
{
    public override void ActiveState()
    {
        this.heroDash.animator.Play("HeroJump");
        this.heroDash.rgbody2D.AddForce(Vector2.up * this.heroDash.jumpGap);
    }

    public override void FixedUpdate()
    {
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == GameTagConst.Ground)
        {
            this.heroDash.ChangeState(DashStateConst.DashRunState);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == GameTagConst.PTriggerReverseGravity)
        {
            this.heroDash.reverseGravity();
        }
    }
}
