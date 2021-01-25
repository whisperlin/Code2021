using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMathf 
{
    public static float RandStep(float min, float max, float t)
    {
        return Mathf.Clamp01((t - min)/(max-min));
    }

    public static float SmoothStep(float min, float max,float t)
    {
        float f = RandStep( min, max, t);
        return f * f * (3f - 2f * f);
    }

    public static Vector3 Bezier3(Vector3 p0, Vector3 p1,Vector3 p2,float t)
    {
        Vector3 m1 = Vector3.Lerp(p0,p1,t);
        Vector3 m2 = Vector3.Lerp(p1,p2,t);
        return Vector3.Lerp(m1,m2,t);
    }

    public static Vector3 Bezier4(Vector3 p0, Vector3 p1, Vector3 p2,Vector3 p3, float t)
    {
        Vector3 m1 = Vector3.Lerp(p0, p1, t);
        Vector3 m2 = Vector3.Lerp(p1, p2, t);
        return Vector3.Lerp(m1, m2, t);
    }

}
