using UnityEngine;

public class TouchDestroy : MonoBehaviour {

    public MonoBehaviour component1;
    public MonoBehaviour component2;
    public Object object1;
    public bool destroyComponents;
    public bool destroyScript;

	void OnTriggerEnter(Collider col) 
	{
		if (col.name == "Destroy")
        {
            if (destroyComponents)
            {
                //Destroy(component1);
                //Destroy(component2);
                Destroy(object1);
            }
            if (destroyScript)
            {
                Destroy(this);
            }
        }
	}
}
