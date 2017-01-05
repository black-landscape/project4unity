using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerControl : MonoBehaviour
{
	private GameObject[] _lines;

	public GameObject line_prefab;

	void Start()
	{
		this._lines = new GameObject[0];

		for (int i = 0; i < 10; i++) {
			GameObject line = GameObject.Instantiate (line_prefab);
			LineRenderer lineRenderer = line.GetComponent<LineRenderer> ();

			lineRenderer.numPositions = 2;

			lineRenderer.SetPosition (0, new Vector3 (0,i*0.6f,0));
			lineRenderer.SetPosition (1, new Vector3 (1000,i*0.6f,0));
		}

		for (int j = 0; j < 10; j++) {
			GameObject line = GameObject.Instantiate (line_prefab);
			LineRenderer lineRenderer = line.GetComponent<LineRenderer> ();

			lineRenderer.numPositions = 2;

			lineRenderer.SetPosition (0, new Vector3 (j*0.6f,0,0));
			lineRenderer.SetPosition (1, new Vector3 (j*0.6f,1000,0));
		}
	}

	void Update()
	{
		
	}

	void OnGUI()
	{
		
	}
}
