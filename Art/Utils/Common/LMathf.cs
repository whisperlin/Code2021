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
}
