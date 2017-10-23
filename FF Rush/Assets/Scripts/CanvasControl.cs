using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //获取按钮游戏对象
        GameObject btnObj = GameObject.Find("Canvas/Button");
        //获取按钮脚本组件
        UnityEngine.UI.Button btn = (UnityEngine.UI.Button)btnObj.GetComponent<UnityEngine.UI.Button>();
        //添加点击侦听
        btn.onClick.AddListener(onClick);
    }

    void onClick()
    {
        GameObject btnObj = GameObject.Find("Player");

        btnObj.SendMessage("reset", SendMessageOptions.RequireReceiver);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
