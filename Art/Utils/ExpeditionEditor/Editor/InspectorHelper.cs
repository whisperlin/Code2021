using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InspectorHelper  
{
    public delegate bool CustomPropertyFun<T>(SerializedProperty prop, T self,bool drawType);

    protected static void IterateDrawProperty<T>(SerializedProperty prop, CustomPropertyFun<T> fun, T self )
    {
        if (prop.NextVisible(true))
        {
            do
            {
                if (prop.name == "m_Script")
                {
                    //不想显示那个讨厌的m_Script
                }
                else if (fun(prop, self,false))
                {
                    //重定义某个属性.
                }
                else
                {
                    EditorGUILayout.PropertyField(prop, false);
                }
                if (prop.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    IterateDrawProperty<T>(prop.Copy(), fun, self);
                    EditorGUI.indentLevel--;
                }
            } while (prop.NextVisible(false));
        }
    }
    public static void OnPropIterator<T>(CustomPropertyFun<T> fun , SerializedObject serializedObject, UnityEngine.Object target) where T: UnityEngine.Object 
    {
        T self = (T)target;
        serializedObject.Update();
        SerializedProperty prop = serializedObject.GetIterator();
        if (prop.NextVisible(true))
        {
            do
            {
                /*if (prop.name == "m_Script")
                {
                    //不想显示那个讨厌的m_Script
                }
                else 
                */if (fun(prop, self,true))
                {
                    //重定义某个属性.
                }
                else
                {
                    EditorGUILayout.PropertyField(prop, true);
                }
                
                
            }
            while (prop.NextVisible(false));
        }

 
        serializedObject.ApplyModifiedProperties();
    }



    
    public static void OnPropIteratorChild<T>(CustomPropertyFun<T> fun, SerializedObject serializedObject, UnityEngine.Object target) where T : UnityEngine.Object
    {

        T self = (T)target;
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
                else if (fun(prop, self,false))
                {
                    //重定义某个属性.
                }
                else
                {
                    EditorGUILayout.PropertyField(prop, false);
                }
                if (prop.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    IterateDrawProperty<T>(prop.Copy(), fun, self);
                    EditorGUI.indentLevel--;
                }

            }
            while (prop.NextVisible(false));

        }

 
        serializedObject.ApplyModifiedProperties();
    }
}
