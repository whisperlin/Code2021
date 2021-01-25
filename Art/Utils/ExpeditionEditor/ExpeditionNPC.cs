using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ExpeditionDialogEvent
{
    [Header("关闭")]
    Close,
    [Header("战斗")]
    Fight,
}
[System.Serializable]
public class ExpeditionDialogItem  
{
    [Label("回答内容")]
    public string textAsk;
    [Label("事件类型",typeof(ExpeditionDialogEvent))]
    public ExpeditionDialogEvent askEventType;
    
    public ExpeditionNPCDialog dialog;
}
[System.Serializable]
public class ExpeditionNPCDialog  
{
    [Label("NPC问话内容")]
    public string text;
    //[Label("回答项")]
    public ExpeditionDialogItem [] asks;
}

 

public class ExpeditionNPC : MonoBehaviour
{
    [Label("NPC id")]
    public int id = 1;

    //[Label("对话内容")]
    [Header("对话内容")]
    public ExpeditionNPCDialog dialog  ;

  


}
