using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    GameObject playerObject;
    GameObject MapObject;
    // Use this for initialization
    void Start()
    {
        this.playerObject = GameObject.Find(GameObjectConst.Player);
        this.MapObject = GameObject.Find(GameObjectConst.Map);

        UnityEngine.UI.Button BtnReset = (UnityEngine.UI.Button)GameObject.Find("Canvas/BtnReset").GetComponent<UnityEngine.UI.Button>();
        BtnReset.onClick.AddListener(OnResetClick);

        UnityEngine.UI.Button BtnStart = (UnityEngine.UI.Button)GameObject.Find("Canvas/BtnStart").GetComponent<UnityEngine.UI.Button>();
        BtnStart.onClick.AddListener(OnStartClick);

        UnityEngine.UI.Button BtnGenerate = (UnityEngine.UI.Button)GameObject.Find("Canvas/BtnGenerate").GetComponent<UnityEngine.UI.Button>();
        BtnGenerate.onClick.AddListener(OnGenerateClick);
    }

    void OnResetClick()
    {
        this.playerObject.SendMessage("ResetGame", SendMessageOptions.RequireReceiver);
    }

    void OnStartClick()
    {
        this.playerObject.SendMessage("StartGame", SendMessageOptions.RequireReceiver);
    }

    void OnGenerateClick()
    {
        this.MapObject.SendMessage("GenerateMap", SendMessageOptions.RequireReceiver);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
