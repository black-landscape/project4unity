//-------------------------------------------------------------------------------------
//	HeroineDash.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
public class HeroineDash : HeroineBase
{
    public HeroineDash() { }

    public override void ActiveHeroine()
    {
        this.stateName = DashStateConst.DashStandState;
    }
}