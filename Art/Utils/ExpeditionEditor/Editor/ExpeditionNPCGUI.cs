using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(ExpeditionNPC))]
public class ExpeditionNPCGUI : Editor
{
    

     

    bool OnNpcGUIProperty (SerializedProperty prop, ExpeditionNPC self, bool drawType)
    {
        //示例。
        if (prop.name == "dialog")
        {


            EditorGUILayout.PropertyField(prop, drawType);

            //
            return true;
        }
        return false;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //InspectorHelper.OnPropIteratorChild<ExpeditionNPC>( OnNpcGUIProperty,serializedObject,target);
        //InspectorHelper.OnPropIterator<ExpeditionNPC>(OnNpcGUIProperty, serializedObject, target);
    }
}
