//-------------------------------------------------------------------------------------
//	HeroBaseState.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class HeroBaseState
{
    public ActiveTriggerEnum activeTrigger;

    private HeroBase _hero;

    public HeroBase hero
    {
        set
        {
            this._hero = value;
        }
        get
        {
            return this._hero;
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
