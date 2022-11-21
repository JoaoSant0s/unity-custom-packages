using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;
using JoaoSant0s.ServicePackage.Canvases;

namespace JoaoSant0s.ServicePackage.CanvasesEditor
{
    [CustomPropertyDrawer(typeof(CanvasIdAttribute))]
    public class CanvasIdAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                base.OnGUI(position, property, label);
                return;
            }
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            if (EditorGUI.DropdownButton(position, new GUIContent(property.stringValue), FocusType.Passive))
            {
                GenericMenu menu = new GenericMenu();
                string[] options = CanvasConfig.Get().Ids;

                CreateOptionMenu(menu, "-empty-", property);

                foreach (var option in options)
                {
                    CreateOptionMenu(menu, option, property);
                }
                menu.DropDown(position);
            }
            EditorGUI.EndProperty();
        }

        private void CreateOptionMenu(GenericMenu menu, string option, SerializedProperty property)
        {
            string temp = option;
            menu.AddItem(new GUIContent(temp), temp == property.stringValue,
                (o) =>
                {
                    property.stringValue = (string)o;
                    property.serializedObject.ApplyModifiedProperties();
                }, temp);
        }
    }
}
