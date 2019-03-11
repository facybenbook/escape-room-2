#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class ToggleGameView : MonoBehaviour
{
    public bool off;

    void Start()
    {
        if (off)
        {
            EditorWindow.FocusWindowIfItsOpen(typeof(SceneView));
        }
    }
}
#endif
