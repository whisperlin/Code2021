using UnityEngine;
using System.Collections;
using UnityEditor;

// Creates a custom Label on the inspector for all the scripts named ScriptName
// Make sure you have a ScriptName script in your
// project, else this will not work.
[CustomEditor(typeof(SimpleGrid))]

public class SimpleGridGUI : Editor
{

    bool OnGridGUIProperty(SerializedProperty prop, SimpleGrid self, bool drawType)
    {
        //示例。
        if (prop.name == "cells")
        {
 
            return true;
        }
        else if (prop.name == "mRenders")
        {

            return true;
        }
        else if (prop.name == "mesh")
        {

            return true;
        }
        return false;
    }
    
    public override void OnInspectorGUI()
    {
        SimpleGrid t = (SimpleGrid)target;
        EditorGUI.BeginChangeCheck();

        InspectorHelper.OnPropIterator<SimpleGrid>(OnGridGUIProperty, serializedObject, target);
        //base.OnInspectorGUI();
        if (EditorGUI.EndChangeCheck())
        {
            Debug.Log("Update Grid");
            t.UpdateGrid();
        }
    }
}
