//-------------------------------------------------------------------------------------
//	DashRunState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DashRunState : HeroineDashState
{
    public override void ActiveState() { }

    public override void FixedUpdate()
    {
        this.heroineDash.rgbody2D.velocity = new Vector2(this.heroineDash.speed, this.heroineDash.rgbody2D.velocity.y);

        if (InputUtil.touchOnce())
        {
            switch (this.activeTrigger)
            {
                case ActiveTriggerEnum.NONE:
                case ActiveTriggerEnum.JUMP:
                    this.heroineDash.ChangeState(DashStateConst.DashJumpState);
                    break;
                case ActiveTriggerEnum.SLASH:
                    this.heroineDash.ChangeState(DashStateConst.DashSlashState);
                    break;
                case ActiveTriggerEnum.FALL:
                    this.heroineDash.ChangeState(DashStateConst.DashFallState);
                    break;
                case ActiveTriggerEnum.REVERSE_GRAVITY:
                    this.heroineDash.reverseGravity();
                    break;
                case ActiveTriggerEnum.REVERSE_ADVANCE:
                    this.heroineDash.reverseAdvance();
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
                    if (this.heroineDash.gravityDirect == GravityDirectEnum.NORMAL)
                    {
                        //死亡
                    }
                    break;
                case DirectionEnum.DOWN:
                    if (this.heroineDash.gravityDirect == GravityDirectEnum.REVERSE)
                    {
                        //死亡
                    }
                    break;
                case DirectionEnum.LEFT:
                    if (this.heroineDash.advanceDirect == AdvanceDirectEnum.LEFT)
                    {
                        //死亡
                    }
                    break;
                case DirectionEnum.RIGHT:
                    if (this.heroineDash.advanceDirect == AdvanceDirectEnum.RIGHT)
                    {
                        //死亡
                    }
                    break;
                case DirectionEnum.NONE:
                default:
                    break;
            }
            // this.heroineDash.stateName = DashStateConst.DashRunState;
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == GameTagConst.PTriggerReverseGravity)
        {
            this.heroineDash.reverseGravity();
        }

        if (other.transform.tag == GameTagConst.PTriggerReverseAdvance)
        {
            this.heroineDash.reverseAdvance();
        }
    }
}
