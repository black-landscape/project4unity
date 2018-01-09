//-------------------------------------------------------------------------------------
//	HeroineBaseState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HeroineBaseState
{
    protected HeroineBase _heroine;

    public HeroineBase heroine
    {
        set
        {
            this._heroine = value;
        }
    }

    public virtual void FixedUpdate() { }
    public virtual void ActiveState() { }
    public virtual void OnCollisionEnter2D(Collision2D col) { }
}
