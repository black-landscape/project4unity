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

        if (((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space)))
        {
            switch (this.activeTrigger)
            {
                case ActiveTriggerEnum.NONE:
                case ActiveTriggerEnum.JUMP:
                    this.heroineDash.stateName = DashStateConst.DashJumpState;
                    break;
                case ActiveTriggerEnum.SLASH:
                    this.heroineDash.stateName = DashStateConst.DashSlashState;
                    break;
                case ActiveTriggerEnum.FALL:
                    this.heroineDash.stateName = DashStateConst.DashFallState;
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
