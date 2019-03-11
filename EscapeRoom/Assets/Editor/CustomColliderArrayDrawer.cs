using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(CustomColliderArray))]
public class CustomColliderArrayDrawer : PropertyDrawer
{
    Rect moreRects;
    int i = 0; 

    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {
        EditorUtility.SetDirty(prop.serializedObject.targetObject);
        Rect firstRect = new Rect(pos.x, pos.y, pos.width, 16);
        EditorGUI.BeginProperty(firstRect, label, prop);
        SerializedProperty array = prop.FindPropertyRelative("cols");
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        EditorGUI.indentLevel = indent;
        EditorGUI.PropertyField(firstRect, array.FindPropertyRelative("Array.size"), label);
        EditorGUI.EndProperty();

        EditorGUI.BeginProperty(moreRects, label, prop);
        for (i = 0; i < array.arraySize; i++)
        {
            moreRects = new Rect(pos.x, pos.y + (20 * (i + 1)), pos.width, 16);
            EditorGUI.PropertyField(moreRects, array.GetArrayElementAtIndex(i), new GUIContent("Collider " + (i + 1)));
        }
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
    {
        return (i + 2.5f) * base.GetPropertyHeight(prop, label);
    }
}

