using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ticker 
{
    float lastTime;
    public float dalta = 1f;
    public VoidNotParam callback = null;
    public  Ticker(float _delta = 1f )
    {
        lastTime  =  Time.realtimeSinceStartup;
        this.dalta = _delta;
    }
    public void AddCallBack(VoidNotParam f)
    {
        if (callback == null)
        {
            callback = f;
        }
        else
        {
            callback += f;
        }
    }
    public void Update()
    {
        if (Time.realtimeSinceStartup - lastTime > dalta)
        {
            lastTime += dalta;
            if (null != callback)
                callback();
        }
    }
    public void Reset(float deltaTime=1f)
    {
        lastTime = lastTime + deltaTime;
    }
    
}


public class TickerEX
{
    float lastTime;
    public float minDelta = 1f;
    public VoidFloatParam callback = null;
    public TickerEX(float _delta = 1f )
    {
        lastTime  =  Time.realtimeSinceStartup;
        this.minDelta = _delta;
    }
    public void AddCallBack(VoidFloatParam f)
    {
        if (callback == null)
        {
            callback = f;
        }
        else
        {
            callback += f;
        }
    }
    public void Update()
    {
        float cur = Time.realtimeSinceStartup;
        float _delta = cur - lastTime;
        if (_delta > minDelta)
        {
            if (null != callback)
            {
                float used = _delta - _delta % minDelta;
                callback(used);
                lastTime += used;
            }
                
        }
    }
    public void Reset(float deltaTime=1f)
    {
        lastTime = lastTime + deltaTime;
        callback = null;
    }
    
}
