//-------------------------------------------------------------------------------------
//	Heroine.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
public class Heroine : MonoBehaviour
{
    public Rigidbody2D rgbody2D;

    private HeroineBaseState _heroState;

    private string _heroStateName;

    private Hashtable _heroStateMap;

    public Heroine()
    {
        this._heroStateMap = new Hashtable();
        this.heroStateName = HeroineStateConst.HeroineStandState;
    }

    public string heroStateName
    {
        get
        {
            return this._heroStateName;
        }
        set
        {
            if (this._heroStateName == "" && this._heroStateName == value)
            {
                return;
            }
            this._heroStateName = value;
            if (this._heroStateMap.Contains(this._heroStateName))
            {
                this._heroState = (HeroineBaseState)this._heroStateMap[this._heroStateName];
            }
            else
            {
                this._heroState = (HeroineBaseState)Activator.CreateInstance(Type.GetType(this._heroStateName), true);//根据类型创建实例
                this._heroState.heroine = this;
                this._heroStateMap.Add(this._heroStateName, this._heroState);
            }
            this._heroState.ActiveState();
        }
    }

    void Start()
    {
        this.rgbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this._heroState != null)
        {
            this._heroState.HandleInput();
        }
    }

    void reset()
    {
        this.rgbody2D.position = new Vector2(0, Mathf.Round(this.rgbody2D.position.y));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            this.heroStateName = HeroineStateConst.HeroineRunState;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        // if (col.transform.tag == "Ground")
        // {
        //     this._isGrounded = false;
        // }
    }
}