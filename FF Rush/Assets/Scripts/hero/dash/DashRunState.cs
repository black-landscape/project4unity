//-------------------------------------------------------------------------------------
//	DashRunState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashRunState : HeroDashState
{
    public override void ActiveState()
    {
        this.heroDash.animator.Play("HeroRun");

    }

    public override void FixedUpdate()
    {
        this.heroDash.rgbody2D.velocity = new Vector2(this.heroDash.speed, this.heroDash.rgbody2D.velocity.y);

        if (InputUtil.touchOnce())
        {
            switch (this.activeTrigger)
            {
                case ActiveTriggerEnum.NONE:
                case ActiveTriggerEnum.JUMP:
                    this.heroDash.ChangeState(DashStateConst.DashJumpState);
                    break;
                case ActiveTriggerEnum.SLASH:
                    this.heroDash.ChangeState(DashStateConst.DashSlashState);
                    break;
                case ActiveTriggerEnum.FALL:
                    this.heroDash.ChangeState(DashStateConst.DashFallState);
                    break;
                case ActiveTriggerEnum.REVERSE_GRAVITY:
                    this.heroDash.reverseGravity();
                    break;
                case ActiveTriggerEnum.REVERSE_ADVANCE:
                    this.heroDash.reverseAdvance();
                    break;
            }
        }
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == GameTagConst.Ground)
        {
            DirectionEnum direct = GameUtil.GetDirection(other.contacts[0].normal);
            switch (direct)
            {
                case DirectionEnum.UP:
                    if (this.heroDash.gravityDirect == GravityDirectEnum.NORMAL)
                    {
                        //死亡
                    }
                    break;
                case DirectionEnum.DOWN:
                    if (this.heroDash.gravityDirect == GravityDirectEnum.REVERSE)
                    {
                        //死亡
                    }
                    break;
                case DirectionEnum.LEFT:
                    if (this.heroDash.advanceDirect == AdvanceDirectEnum.LEFT)
                    {
                        //死亡
                    }
                    break;
                case DirectionEnum.RIGHT:
                    if (this.heroDash.advanceDirect == AdvanceDirectEnum.RIGHT)
                    {
                        //死亡
                    }
                    break;
                case DirectionEnum.NONE:
                default:
                    break;
            }
            // this.heroDash.stateName = DashStateConst.DashRunState;
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == GameTagConst.PTriggerReverseGravity)
        {
            this.heroDash.reverseGravity();
        }

        if (other.transform.tag == GameTagConst.PTriggerReverseAdvance)
        {
            this.heroDash.reverseAdvance();
        }
    }
}
