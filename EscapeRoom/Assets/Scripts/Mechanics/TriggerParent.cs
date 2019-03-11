using UnityEngine;

public class TriggerParent : MonoBehaviour {

    public KeyTurn keyturn;
    [ReadOnly] public float i;
    [ReadOnly] public int x = 0;

    public void CheckTriggers()
    {
        if (x == 2 && i > 0)
        {
            keyturn.rightTime = true;
        }
        else
        {
            keyturn.rightTime = false;
        }
    }
}
