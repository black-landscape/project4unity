using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject beamPrefab;

    private Dictionary<PoolEnum, List<GameObject>> _poolDict;

    private bool _isInit;

    void Start()
    {
        
    }

    public void pushToPool(PoolEnum key, GameObject obj)
    {
        this.checkInit();

        if (this._poolDict.ContainsKey(key))
        {
            this._poolDict[key].Add(obj);
        }
        else
        {
            this._poolDict.Add(key, new List<GameObject>());
        }
    }

    public GameObject pullFromPool(PoolEnum key)
    {
        this.checkInit();

        GameObject obj;

        if (this._poolDict.ContainsKey(key) && this._poolDict[key].Count > 0)
        {
            obj = this._poolDict[key][0];
            this._poolDict[key].RemoveAt(0);
        }
        else
        {
            switch (key)
            {
                case PoolEnum.BEAM:
                    obj = Instantiate(beamPrefab) as GameObject;
                    break;
                default:
                    obj = null;
                    break;
            }
        }

        return obj;
    }

    private void checkInit()
    {
        if (!this._isInit)
        {
            this._isInit = true;
            this._poolDict = new Dictionary<PoolEnum, List<GameObject>>();

            beamPrefab = Resources.Load("Prefabs/beam_prefab", typeof(GameObject)) as GameObject;
        }
    }
}

public enum PoolEnum{
    BEAM
}
