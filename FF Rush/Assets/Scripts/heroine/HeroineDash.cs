//-------------------------------------------------------------------------------------
//	HeroineDash.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
public class HeroineDash : HeroineBase
{
    public int speed;     //通常移动速度;
    public int gravity;   //通常重力
    public int jumpGap;      //跳起力量
    public int fallGap;     //下落力量
    public GravityDirectEnum gravityDirect;     //重力方向
    public AdvanceDirectEnum advanceDirect;     //冲刺方向

    public HeroineDash()
    {
        this.speed = GameConst.DASH_RIGHT_SPEED;
        this.gravity = GameConst.DASH_NORMAL_GRAVITY;
        this.jumpGap = GameConst.DASH_NORMAL_JUMP_GAP;
    }

    public override void ActiveHeroine()
    {
        this.stateName = DashStateConst.DashStandState;
        this.rgbody2D.gravityScale = this.gravity;
    }

    public void reverseGravity()
    {
        if (this.gravityDirect == GravityDirectEnum.NORMAL)
        {
            this.gravityDirect = GravityDirectEnum.REVERSE;
            this.gravity = GameConst.DASH_REVERSE_GRAVITY;
            this.jumpGap = GameConst.DASH_REVERSE_JUMP_GAP;
        }
        else
        {
            this.gravityDirect = GravityDirectEnum.NORMAL;
            this.gravity = GameConst.DASH_NORMAL_GRAVITY;
            this.jumpGap = GameConst.DASH_NORMAL_JUMP_GAP;
        }
        this.rgbody2D.gravityScale = this.gravity;
    }

    public void reverseAdvance()
    {
        if (this.advanceDirect == AdvanceDirectEnum.RIGHT)
        {
            this.advanceDirect = AdvanceDirectEnum.LEFT;
            this.speed = GameConst.DASH_LEFT_SPEED;
        }
        else
        {
            this.advanceDirect = AdvanceDirectEnum.RIGHT;
            this.speed = GameConst.DASH_RIGHT_SPEED;
        }
    }
}