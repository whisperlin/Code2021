using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(ExpeditionEvent))]
public class ExpeditionEventGUI : Editor
{
   
    public void OnSimpleGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("eventType"), true);
        serializedObject.ApplyModifiedProperties();
    }
    public delegate bool CustomPropertyFun(SerializedObject serializedObject, string name, ExpeditionEvent self);
    public void OnPropIterator(CustomPropertyFun fun)
    {
        ExpeditionEvent self = (ExpeditionEvent)target;
        serializedObject.Update();
        SerializedProperty prop = serializedObject.GetIterator();
        if (prop.NextVisible(true))
        {
            do
            {
                if (prop.name == "m_Script")
                {
                    //不想显示那个讨厌的m_Script
                }
                else if (fun(serializedObject, prop.name, self))
                {
                    //重定义某个属性.
                }
                else
                {
                    EditorGUILayout.PropertyField(serializedObject.FindProperty(prop.name), true);
                }
            }
            while (prop.NextVisible(false));
        }
        serializedObject.ApplyModifiedProperties();
    }
    public override void OnInspectorGUI()
    {
        ExpeditionEvent expeditionEvent = (ExpeditionEvent)target;
        switch (expeditionEvent.eventType)
        {
            /*case  ExpeditionEvent.Type.NPC:
                {
                    OnPropIterator(ExpeditionNpcPropertyGUI.OnNpcGUIProperty);
                }
                break;*/
            default:
                {
                    OnSimpleGUI();
                    //base.OnInspectorGUI();
                }
                break;
                
        }
        
    }



}

 