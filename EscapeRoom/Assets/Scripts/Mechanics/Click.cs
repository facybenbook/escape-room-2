using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

    public BookWatch bookwatch;

#if UNITY_EDITOR
    void OnMouseDown()
    {
        BookWatch.force = true;
        bookwatch.SafeUnlock();
    }
#endif

#if UNITY_IOS || UNITY_ANDROID
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    BookWatch.force = true;
                    bookwatch.SafeUnlock();
                }
            }
        }
    }
#endif
}
