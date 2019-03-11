using UnityEngine;

public class TimeTrigger : MonoBehaviour {

    [ReadOnly] public bool triggered;
    TriggerParent parent;

    void Start()
    {
        parent = GetComponentInParent<TriggerParent>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == name)
        {
            triggered = true;
            parent.x++;
            parent.CheckTriggers();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == name)
        {
            triggered = false;
            parent.x--;
            parent.CheckTriggers();
        }
    }
}
