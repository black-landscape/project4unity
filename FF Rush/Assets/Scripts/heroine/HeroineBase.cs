//-------------------------------------------------------------------------------------
//	Heroine.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
public class HeroineBase
{
    public Rigidbody2D rgbody2D;
    protected HeroineBaseState _state;  //当前状态对象
    protected string _stateName;    //当前状态名称
    protected Hashtable _stateMap;      //状态map

    public HeroineBase()
    {
        this._stateMap = new Hashtable();
    }

    public virtual void ActiveHeroine() { }

    public void ChangeState(string value, object data = null)
    {
        if (this._stateName == "" && this._stateName == value)
        {
            return;
        }
        this._stateName = value;
        if (this._stateMap.Contains(this._stateName))
        {
            this._state = (HeroineBaseState)this._stateMap[this._stateName];
        }
        else
        {
            this._state = (HeroineBaseState)Activator.CreateInstance(Type.GetType(this._stateName), true);//根据类型创建实例
            this._state.heroine = this;
            this._stateMap.Add(this._stateName, this._state);
        }
        if (data != null)
        {
            this._state.ActiveState(data);
        }
        else
        {
            this._state.ActiveState();
        }
    }

    public string stateName
    {
        get
        {
            return this._stateName;
        }
    }

    public virtual void FixedUpdate()
    {
        if (this._state != null)
        {
            this._state.FixedUpdate();
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (this._state != null)
        {
            this._state.OnCollisionEnter2D(other);
        }
    }

    public virtual void OnCollisionExit2D(Collision2D other)
    {
        if (this._state != null)
        {
            this._state.OnCollisionExit2D(other);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (this._state != null)
        {
            this._state.OnTriggerEnter2D(other);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (this._state != null)
        {
            this._state.OnTriggerExit2D(other);
        }
    }
}