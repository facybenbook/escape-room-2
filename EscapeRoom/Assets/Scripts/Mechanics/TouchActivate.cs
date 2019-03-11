using UnityEngine;

public class TouchActivate : MonoBehaviour {

    public MonoBehaviour component;

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Activate")
        {
            component.enabled = true;
            Destroy(col.gameObject);
        }
    }
}
