using UnityEngine;
using System.Collections;

public class ShortHand : MonoBehaviour
{

    void Update()
    {
        if (BreakClock.clockBroken == false)
        {
            transform.rotation *= Quaternion.AngleAxis(-Time.deltaTime/12, Vector3.forward);
        }
        else
        {
            transform.rotation *= Quaternion.AngleAxis(LongHand.angleDelta, Vector3.forward);
        }
    }
}
