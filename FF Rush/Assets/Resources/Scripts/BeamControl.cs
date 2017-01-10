using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamControl : MonoBehaviour
{
	private List<GameObject> _lines;

	void Start()
	{
        this._lines = new List<GameObject>();

        PoolManager pm = Singleton.getInstance("PoolManager") as PoolManager;
		for (int i = 0; i < 20; i++) {
            GameObject line = pm.pullFromPool(PoolEnum.BEAM);
			LineRenderer lineRenderer = line.GetComponent<LineRenderer> ();

			lineRenderer.numPositions = 2;
			lineRenderer.SetPosition (0, new Vector3 (0,i*0.6f,0));
			lineRenderer.SetPosition (1, new Vector3 (1000,i*0.6f,0));

            this._lines.Add(line);
        }

		for (int j = 0; j < 40; j++) {
            GameObject line = pm.pullFromPool(PoolEnum.BEAM);
            LineRenderer lineRenderer = line.GetComponent<LineRenderer> ();

			lineRenderer.numPositions = 2;
			lineRenderer.SetPosition (0, new Vector3 (j*0.6f,0,0));
			lineRenderer.SetPosition (1, new Vector3 (j*0.6f,1000,0));

            this._lines.Add(line);
        }
    }

	void Update()
	{
		
	}

	void OnGUI()
	{
		
	}
}
