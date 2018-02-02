//-------------------------------------------------------------------------------------
//	HeroControl.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
public class HeroControl : MonoBehaviour
{
    public Rigidbody2D rgbody2D;
    public Animator animator;
    private HeroBase _hero;   //当前英雄对象
    private string _pattern;   //当前英雄模式
    private Hashtable _patternMap;  //英雄模式map

    public HeroControl() { }

    void Start()
    {
        this._patternMap = new Hashtable();
        this.pattern = HeroPatternConst.HeroDash;
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
                this._hero = (HeroBase)this._patternMap[this._pattern];
            }
            else
            {
                this._hero = (HeroBase)Activator.CreateInstance(Type.GetType(this._pattern), true);//根据类型创建实例
                this._hero.rgbody2D = this.rgbody2D;
                this._hero.animator = this.animator;
                this._patternMap.Add(this._pattern, this._hero);
            }
            this._hero.ActiveHero();
        }
    }

    void FixedUpdate()
    {
        if (this._hero != null)
        {
            this._hero.FixedUpdate();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (this._hero != null)
        {
            this._hero.OnCollisionEnter2D(other);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (this._hero != null)
        {
            this._hero.OnCollisionExit2D(other);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this._hero != null)
        {
            this._hero.OnTriggerEnter2D(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (this._hero != null)
        {
            this._hero.OnTriggerEnter2D(other);
        }
    }

    void ResetGame()
    {
        this.rgbody2D.position = new Vector2(0, Mathf.Round(this.rgbody2D.position.y));
    }

    void StarGame()
    {

    }
}