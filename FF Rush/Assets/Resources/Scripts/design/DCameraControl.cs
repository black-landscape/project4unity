using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCameraControl : MonoBehaviour {
    private float _gapX;
    private float _gapY;


    // Use this for initialization
    void Start () {
        //StartCoroutine(OnMouseDown());
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标滚轮的效果
        //Camera.main.fieldOfView 摄像机的视野
        //Camera.main.orthographicSize 摄像机的正交投影
        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 20)
                Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 0.5F;
        }


        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            //Debug.Log("mposX---" + mpos.x);
            //Debug.Log("mposY---" + mpos.y);
            //Debug.Log("stageX---" + Input.mousePosition.x);
            //Debug.Log("stageY---" + Input.mousePosition.y);

            this._gapX = this.transform.position.x - mpos.x;
            this._gapY = this.transform.position.y - mpos.y;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 mpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            this.transform.position = new Vector3(mpos.x + this._gapX, mpos.y+ this._gapY, this.transform.position.z);

            //Debug.Log("mposX---" + mpos.x);
            //Debug.Log("mposY---" + mpos.y);
            //Debug.Log("stageX---" + Input.mousePosition.x);
            //Debug.Log("stageY---" + Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(1))
        {
            this._gapX = 0;
            this._gapY = 0;
        }
    }

    IEnumerator OnMouseDown()
    {
        //将物体由世界坐标系转换为屏幕坐标系
        Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);//三维物体坐标转屏幕坐标
        //完成两个步骤 1.由于鼠标的坐标系是2维，需要转换成3维的世界坐标系 
        //    //             2.只有3维坐标情况下才能来计算鼠标位置与物理的距离，offset即是距离
        //将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        while (Input.GetMouseButton(0))
        {
            //得到现在鼠标的2维坐标系位置
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            //将当前鼠标的2维位置转换成3维位置，再加上鼠标的移动量
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            //curPosition就是物体应该的移动向量赋给transform的position属性
            transform.position = curPosition;
            yield return new WaitForFixedUpdate(); //这个很重要，循环执行
        }
    }
}