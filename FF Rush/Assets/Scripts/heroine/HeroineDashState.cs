//-------------------------------------------------------------------------------------
//	HeroineBaseState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HeroineDashState : HeroineBaseState
{
    public HeroineDash heroineDash
    {
        get
        {
            return (HeroineDash)this._heroine;
        }
    }
}
