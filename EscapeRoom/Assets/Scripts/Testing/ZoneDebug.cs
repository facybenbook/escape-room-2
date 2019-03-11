using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDebug : MonoBehaviour {

    ZoneCheck[] zoneCheckList;

	void Start () 
    {
        zoneCheckList = GetComponentsInChildren<ZoneCheck>();
	}
	
	public void ZoneDebugFunc() 
    {
		foreach (ZoneCheck zone in zoneCheckList)
        {
            Debug.Log("Zone " + zone.zoneNumber + ": " + "Counter " + zone.counter + ", should be " + zone.zoneValue);
        }
	}
}
