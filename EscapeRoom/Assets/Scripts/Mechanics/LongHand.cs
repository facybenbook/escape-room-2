using UnityEngine;
using System.Collections;

public class LongHand : MonoBehaviour {

    float baseAngle = 0.0f;
    public static float angle;
    public static float angleDelta;
    public Transform hourHand;
    public ReflectionProbe probe;

    void Start()
    {
        StartCoroutine(MinuteHand());
    }

    void OnMouseDown()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg; //base quaternion to start from
        baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg; //increment start point by touch position
    }

    void OnMouseDrag()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position); //long hand position
        Vector3 rot = transform.eulerAngles;
        pos = Input.mousePosition - pos; //direction
        angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle; //angle moved
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //rotate to angle (point, not delta)
        angleDelta = (Mathf.DeltaAngle(rot.z, angle))/12;
        hourHand.rotation *= Quaternion.AngleAxis(angleDelta, Vector3.forward);
        probe.RenderProbe();
    }

    void OnMouseUp()
    {
        angleDelta = 0;
    }

    IEnumerator MinuteHand()
    {
        while (!BreakClock.clockBroken)
        {
            hourHand.rotation *= Quaternion.AngleAxis(-Time.deltaTime / 12, Vector3.forward);
            transform.rotation *= Quaternion.AngleAxis(-Time.deltaTime, Vector3.forward);
            yield return null;
        }
    }
}
