//-------------------------------------------------------------------------------------
//	HeroineBaseState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HeroineBaseState
{
    protected Heroine _heroine;

    public Heroine heroine
    {
        set
        {
            this._heroine = value;
        }
    }

    public virtual void HandleInput() { }
    public virtual void ActiveState() { }
}
