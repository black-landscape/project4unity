//-------------------------------------------------------------------------------------
//	HeroineControl.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
public class HeroineControl : MonoBehaviour
{
    public Rigidbody2D rgbody2D;
    private HeroineBase _heroine;   //当前英雄对象
    private string _pattern;   //当前英雄模式
    private Hashtable _patternMap;  //英雄模式map

    public HeroineControl() { }

    void Start()
    {
        this._patternMap = new Hashtable();
        this.pattern = HeroinePatternConst.HeroineDash;
    }

    public string pattern
    {
        get
        {
            return this._pattern;
        }
        set
        {
            if (this._pattern == "" && this._pattern == value)
            {
                return;
            }
            this._pattern = value;
            if (this._patternMap.Contains(this._pattern))
            {
                this._heroine = (HeroineBase)this._patternMap[this._pattern];
            }
            else
            {
                this._heroine = (HeroineBase)Activator.CreateInstance(Type.GetType(this._pattern), true);//根据类型创建实例
                this._heroine.rgbody2D = this.rgbody2D;
                this._patternMap.Add(this._pattern, this._heroine);
            }
            this._heroine.ActiveHeroine();
        }
    }

    void FixedUpdate()
    {
        if (this._heroine != null)
        {
            this._heroine.FixedUpdate();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (this._heroine != null)
        {
            this._heroine.OnCollisionEnter2D(col);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (this._heroine != null)
        {
            this._heroine.OnCollisionExit2D(col);
        }
    }

    void reset()
    {
        this.rgbody2D.position = new Vector2(0, Mathf.Round(this.rgbody2D.position.y));
    }
}