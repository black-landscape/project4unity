//-------------------------------------------------------------------------------------
//	MapControl.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
public class MapControl : MonoBehaviour
{
    void Start()
    {

    }
    void GenerateMap()
    {
        // Transform[] grandFa = GetComponentsInChildren<Transform>();


        foreach (Component component in this.gameObject.GetComponents<Component>())
        {
            print(component.GetType());
        }


        // foreach (Transform child in grandFa)
        // {
        //     print(child.name);
        // }
    }
}