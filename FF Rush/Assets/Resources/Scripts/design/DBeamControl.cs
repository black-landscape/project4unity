using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBeamControl : MonoBehaviour
{
	private List<GameObject> _hlines;

    private List<GameObject> _vlines;

    private GameObject _gobj;

	void Start()
	{
        this._gobj = GameObject.FindGameObjectWithTag("MainCamera");



        this._hlines = new List<GameObject>();
        this._vlines = new List<GameObject>();


        PoolManager pm = Singleton.getInstance("PoolManager") as PoolManager;
		for (int i = 0; i < GameConst.HBEAM_COUNT; i++) {
            GameObject line = pm.pullFromPool(PoolEnum.BEAM);
			LineRenderer lineRenderer = line.GetComponent<LineRenderer> ();

			lineRenderer.numPositions = 2;
			lineRenderer.SetPosition (0, new Vector3 (0,i*GameConst.TILE_HEIGHT,0));
			lineRenderer.SetPosition (1, new Vector3 (GameConst.BEAM_LENGTH,i*GameConst.TILE_HEIGHT, 0));

            line.transform.parent = this.gameObject.transform;

            this._hlines.Add(line);
        }

		for (int j = 0; j < GameConst.VBEAM_COUNT; j++) {
            GameObject line = pm.pullFromPool(PoolEnum.BEAM);
            LineRenderer lineRenderer = line.GetComponent<LineRenderer> ();

			lineRenderer.numPositions = 2;
			lineRenderer.SetPosition (0, new Vector3 (j* GameConst.TILE_WIDTH, 0,0));
			lineRenderer.SetPosition (1, new Vector3 (j* GameConst.TILE_WIDTH, GameConst.BEAM_LENGTH, 0));

            line.transform.parent = this.gameObject.transform;

            this._vlines.Add(line);
        }
    }

	void Update()
	{
		
	}

	void OnGUI()
	{
        //Debug.Log("cameraX---" + this._gobj.transform.position.x);
        //Debug.Log("cameraY---" + this._gobj.transform.position.y);

        int countX = (int)(this._gobj.transform.position.x / GameConst.TILE_WIDTH);
        int countY = (int)(this._gobj.transform.position.y / GameConst.TILE_HEIGHT);

        //Debug.Log("countX---" + countX);
        //Debug.Log("countY---" + countY);


        for (int i = 0; i < this._hlines.Count; i++)
        {
            LineRenderer lineRenderer = this._hlines[i].GetComponent<LineRenderer>();

            lineRenderer.SetPosition(0, new Vector3(countX * GameConst.TILE_WIDTH - GameConst.BEAM_LENGTH, (i - GameConst.VBEAM_COUNT / 2) * GameConst.TILE_HEIGHT + countY * GameConst.TILE_HEIGHT, 0));
            lineRenderer.SetPosition(1, new Vector3(countX * GameConst.TILE_WIDTH + GameConst.BEAM_LENGTH, (i - GameConst.VBEAM_COUNT / 2) * GameConst.TILE_HEIGHT + countY * GameConst.TILE_HEIGHT, 0));
        }

        for (int j = 0; j < this._vlines.Count; j++)
        {
            LineRenderer lineRenderer = this._vlines[j].GetComponent<LineRenderer>();

            lineRenderer.numPositions = 2;
            lineRenderer.SetPosition(0, new Vector3((j - GameConst.HBEAM_COUNT / 2) * GameConst.TILE_WIDTH + countX * GameConst.TILE_WIDTH, countY * GameConst.TILE_HEIGHT - GameConst.BEAM_LENGTH, 0));
            lineRenderer.SetPosition(1, new Vector3((j - GameConst.HBEAM_COUNT / 2) * GameConst.TILE_WIDTH+ countX * GameConst.TILE_WIDTH, countY * GameConst.TILE_HEIGHT + GameConst.BEAM_LENGTH, 0));
        }
    }
}