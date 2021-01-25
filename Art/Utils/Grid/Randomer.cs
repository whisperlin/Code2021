using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class Randomer : MonoBehaviour
{
    public float radius = 0.3f;

    public Vector3[] points;
    public static int TransformRotationToInt(Vector2 translation,float rot)
    {
        translation.x = translation.x % 1;
        return (int)(10*translation.x +  100*translation.y  +  rot * 10000);
    }

    public static void GetTransformRotation(int value,out Vector3 translation,out float rot)
    {
        translation.x =  0.1f*( value % 10 );
        value = value / 10;
        translation.z = 0.1f*(value % 10);
        translation.y = 0f;
        value = value / 10;
        rot = 0.01f*value;
    }

    public static Matrix4x4 GetTransformRotation(int value,float _scale)
    {
        Vector3 translation;
        float a;
        GetTransformRotation(value,out translation,out a);
        Quaternion rotation = Quaternion.Euler(0f, a, 0f);
        Vector3 scale = new Vector3(1/ _scale, 1/ _scale, 1/ _scale);
        Matrix4x4 m = Matrix4x4.identity;
        m.SetTRS(translation, rotation, scale);
        return m;
    }


}
