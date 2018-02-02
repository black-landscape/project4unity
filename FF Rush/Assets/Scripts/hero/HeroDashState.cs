//-------------------------------------------------------------------------------------
//	HeroDashState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HeroDashState : HeroBaseState
{
    public HeroDash heroDash
    {
        get
        {
            return (HeroDash)this.hero;
        }
    }
}
