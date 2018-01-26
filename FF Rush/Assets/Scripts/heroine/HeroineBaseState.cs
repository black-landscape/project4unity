//-------------------------------------------------------------------------------------
//	HeroineBaseState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HeroineBaseState
{
    public ActiveTriggerEnum activeTrigger;

    private HeroineBase _heroine;

    public HeroineBase heroine
    {
        set
        {
            this._heroine = value;
        }
        get
        {
            return this._heroine;
        }
    }

    public virtual void FixedUpdate() { }
    public virtual void ActiveState() { }
    public virtual void ActiveState(object data) { }
    public virtual void OnCollisionEnter2D(Collision2D other) { }
    public virtual void OnCollisionExit2D(Collision2D other) { }
    public virtual void OnTriggerEnter2D(Collider2D other) { }
    public virtual void OnTriggerExit2D(Collider2D other) { }
    public virtual void Reset() { }
}
