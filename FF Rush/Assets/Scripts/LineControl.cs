using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControl : MonoBehaviour 
{
	private LineRenderer _lineRenderer;
	public float startX;
	public float startY;
	public float endX;
	public float endY;

	// Use this for initialization
	void Start () 
	{
		this._lineRenderer = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void drawLine()
	{
		Debug.Log ("startX---" + this.startX);
		Debug.Log ("startY---" + this.startY);

		this._lineRenderer.numPositions = 2;

		this._lineRenderer.SetPosition (0, new Vector3 (this.startX,this.startY,0));
		this._lineRenderer.SetPosition (1, new Vector3 (this.endX,this.endY,0));
	}
}
