using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CmdTools  
{
    [MenuItem("工具/更新/更新Android")]
    public static void UpdateAndroid()
    {
        CallCmd("android_update.bat");
    }

    static void CallCmd(string cmd)
    {

        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        try
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            myProcess.StartInfo.CreateNoWindow = false;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe";
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 6) + "\\" + cmd;
            myProcess.StartInfo.Arguments = "/c" + path;
            myProcess.EnableRaisingEvents = true;
            myProcess.Start();
            myProcess.WaitForExit();
            int ExitCode = myProcess.ExitCode;
            //print(ExitCode);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }
}
