using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(CustomFlare))]
public class CustomFlareDrawer : PropertyDrawer
{

    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {
        EditorUtility.SetDirty(prop.serializedObject.targetObject);
        SerializedProperty aF = prop.FindPropertyRelative("addFlare");
        SerializedProperty flare = prop.FindPropertyRelative("flare");
        SerializedProperty fZi = prop.FindPropertyRelative("fZi");
        SerializedProperty fZo = prop.FindPropertyRelative("fZo");
        Rect rect1 = new Rect(pos.x, pos.y, pos.width, 16);
        EditorGUI.BeginProperty(rect1, label, prop);
        EditorGUI.PropertyField(rect1, aF, label);
        EditorGUI.EndProperty();
        if (aF.boolValue == true)
        {
            Rect rect2 = new Rect(pos.x, pos.y + 20, pos.width, 16);
            EditorGUI.BeginProperty(rect2, label, prop);
            EditorGUI.PropertyField(rect2, flare, label);
            EditorGUI.EndProperty();
            Rect rect3 = new Rect(pos.x, pos.y + 40, pos.width, 16);
            EditorGUI.BeginProperty(rect3, label, prop);
            EditorGUI.PropertyField(rect3, fZi, new GUIContent("Flare Zoomed In"));
            EditorGUI.EndProperty();
            Rect rect4 = new Rect(pos.x, pos.y + 60, pos.width, 16);
            EditorGUI.BeginProperty(rect4, label, prop);
            EditorGUI.PropertyField(rect4, fZo, new GUIContent("Flare Zoomed Out"));
            EditorGUI.EndProperty();
        }
    }

    public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
    {
        SerializedProperty aF = prop.FindPropertyRelative("addFlare");
        if (aF.boolValue == true)
        {
            return (4.5f) * base.GetPropertyHeight(prop, label);
        }
        else
        {
            return base.GetPropertyHeight(prop, label);
        }
    }
}

