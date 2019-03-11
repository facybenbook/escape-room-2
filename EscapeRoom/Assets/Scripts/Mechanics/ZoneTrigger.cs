using UnityEngine;
using System.Collections.Generic;

public class ZoneTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider zone)
    {
        if (zone.tag == "zone")
        {
            ZoneCheck zc = zone.GetComponent<ZoneCheck>();
            zc.CounterUp();
        }
    }

    void OnTriggerExit(Collider zone)
    {
        if (zone.tag == "zone")
        {
            ZoneCheck zc = zone.GetComponent<ZoneCheck>();
            zc.CounterDown();
        }
    }
}
