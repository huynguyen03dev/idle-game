using UnityEngine;
using System;

namespace UnityUtils {
    [AttributeUsage (AttributeTargets.Field,Inherited = true)]
    public class ReadOnlyAttribute : PropertyAttribute {}

#if UNITY_EDITOR
    [UnityEditor.CustomPropertyDrawer (typeof(ReadOnlyAttribute))]
    public class ReadOnlyAttributeDrawer : UnityEditor.PropertyDrawer
    {
        public override void OnGUI(Rect rect, UnityEditor.SerializedProperty prop, GUIContent label)
        {
            bool wasEnabled = GUI.enabled;
            GUI.enabled = false;
            UnityEditor.EditorGUILayout.PropertyField(prop, label, true);
            GUI.enabled = wasEnabled;
        }
    }
#endif
}

