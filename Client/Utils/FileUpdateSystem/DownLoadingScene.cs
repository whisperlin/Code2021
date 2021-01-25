using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownLoadInformation
{
    public string path;
    public string Local_path;
    public string md5;
    public int size;
    public bool type1 = true;
    public string name;
}

public class DownLoadABInformation
{
    public string path;
    public string md5;
    public int size;
    
}
//path":"Android","md5":"29D6A2D612C2B11758D31EB6F0957109","size":
public class DownloadTableInforation
{


    public string flieName;
    public int size;
    public string extName;
    public string md5;


}


public class DownLoadingScene : MonoBehaviour
{
    //AsyncOperation async;
    public Slider progressSlidr;
    public Text progressValueText;
    public Text progressMessageText;
    public string nextScene =  "MainScene";
    //public float text_num = 0;    //进度值
    public static DownLoadingScene instance = null;
    public static string serverRoot = "http://192.168.0.12";
    public static string table_server = "http://192.168.0.11";
    public static string pathfrom = "Android";
    public static string version = "000001";


    private static string FtpServer_Res_IP = "";//ftp
    private static string FtpLocal_Res_IP = "";//ftp
    //private string LOCAL_FTP_RES_PATH = ""; //更新资源的本地地址
    private string Local_Http_List = "";//htpp更新列表的本地地址

    private string SERVER_RES_URL_Bundle = "";//服务器目标文件地址

 
    

    public string GetRoot()//返回路径
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        return Application.persistentDataPath + "/";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"/";
#else
        return Application.persistentDataPath+"/";
#endif
    }
    IEnumerator UpdateFileForServer()
    {
        
        string downloadRoot = serverRoot + "/" + pathfrom + "/" + version + "/";
        string ab_list = downloadRoot + "files.version";
        string table_serverRoot = table_server + ":8080/";
        string table_list = table_serverRoot + "ajaxVersionList";//http
        string table_bundle_ip = table_serverRoot + "ajaxConfigFile?jsonName=";
        List<DownLoadInformation> downLoadInformationList = new List<DownLoadInformation>();

        List<DownLoadABInformation> assetbundleList = new List<DownLoadABInformation>();

        Dictionary<string, DownloadTableInforation> tableList = new Dictionary<string, DownloadTableInforation>();
        Debug.Log(GetRoot());
        yield return new WaitForSeconds(0.1f);
        
        string bundleListPath = GetRoot() + "files.version";
        //下载ab包更新列表
        //DownLoadingScene.instance.SetProgressBar(0);
        float total_size = 0f;
        float curSize = 0f;
        float text_num = 0.5f;
        float text_num_100 = 50;
        DownLoadingScene.instance.SetProgressBar(0f);
        HttpHandle handle = HttpHelper.StartDownLoad(this, ab_list, bundleListPath);
        while (!handle.isFinish)
        {

            progressValueText.text = text_num_100.ToString() + "%";
 
            SetProgressBarText("正在下载更新列表files.version");
            DownLoadingScene.instance.SetProgressBar(text_num);
            

            yield return null;
        }

        if (handle.HasError)
        {
 
            SetProgressBarText("更新assetbundle列表出错");
 
            yield break;
        }
        string _txt = System.IO.File.ReadAllText(bundleListPath);
        Debug.Log(_txt);
        assetbundleList = JsonConvert.DeserializeObject<List<DownLoadABInformation>>(_txt);

        //下载表格更新列表
        //float curSize = 0f;
        //float total_size = 0f;
        Local_Http_List = GetRoot() + "ajaxVersionList.json";
        handle = HttpHelper.StartDownLoad(this, table_list, Local_Http_List);
        while (!handle.isFinish)
        {
             text_num = 1;
             text_num_100 =100;
            progressValueText.text = text_num_100.ToString() + "%";
 
            SetProgressBarText("正在下载更新列表ajaxVersionList.json");
            DownLoadingScene.instance.SetProgressBar(text_num);
 
            yield return null;
        }

        if (handle.HasError)
        {
            SetProgressBarText("更新服务器列表出错");
            yield break;
        }

        string http_list__txt = System.IO.File.ReadAllText(Local_Http_List);
        Debug.Log(http_list__txt);
        tableList = JsonConvert.DeserializeObject<Dictionary<string, DownloadTableInforation>>(http_list__txt);
 
        DownLoadingScene.instance.SetProgressBar(0.01f);

        float files_count = 0;
        float all_text_md5 =70;
        //Debug.Log("校验ab包 md5");
        foreach (var file in assetbundleList)
        {
            files_count = files_count + 1;
        }
        foreach (var file in tableList)
        {
            files_count = files_count + 1;
        }
        float md5_count = 0;
        foreach (var file in assetbundleList)
        {

            md5_count = md5_count + 1;
            //Debug.Log("files_count:" + files_count+ "  md5_count  "+ md5_count);
            float md5_rate = md5_count / files_count;

            //Debug.Log("md5_rate" + md5_rate);
            float md5_rate_100 = md5_rate * 100;
            md5_rate_100 = (float)Math.Round(md5_rate_100, 1);
            progressValueText.text = md5_rate_100.ToString() + "%";

            SetProgressBarText("正在校验MD5");

            
            DownLoadingScene.instance.SetProgressBar(md5_rate);

            yield return null;
        }
        foreach (var file in tableList)
        {
            md5_count = md5_count + 1;
            float md5_rate = md5_count / files_count;

            float md5_rate_100 = md5_rate * 100;
            md5_rate_100 = (float)Math.Round(md5_rate_100, 1);
            progressValueText.text = md5_rate_100.ToString() + "%";

            SetProgressBarText("正在校验MD5");

            DownLoadingScene.instance.SetProgressBar(md5_rate);
            yield return null;
        }



        foreach (var file in assetbundleList)
        {
            string savePath = GetRoot() + file.path;
            string ab_server_path = downloadRoot + file.path;
            if (System.IO.File.Exists(savePath))
            {
                string _local_path = GetRoot() + file.path;
                string _md5 = GetFileHash(_local_path);
                string Server_md5_ToLower = file.md5.ToLower();

                if (Server_md5_ToLower == _md5)
                {
                    continue;

                }

            }
            //files_count = files_count + 1;
            float md5_rate = files_count / all_text_md5;


            DownLoadInformation di = new DownLoadInformation();
            di.path = ab_server_path;
            di.Local_path = savePath;
            di.md5 = file.md5;
            di.size = file.size;
            di.type1 = true;
            di.name = file.path;
            downLoadInformationList.Add(di);


        }
        //Debug.Log("files_count:"+ files_count);
        Debug.Log("校验json md5");
        //files_count = 0;
        foreach (var file in tableList)
        {

            string savePath = GetRoot() + file.Key;
            string table_server_path = table_bundle_ip + file.Key;
            //Debug.Log("校验" + table_server_path);
            if (System.IO.File.Exists(savePath))
            {
                string _md5 = MD5_StringUTF8(savePath);
                string _server_md5 = file.Value.md5.ToLower();
                //files_count = files_count + 1;
                if (_server_md5 == _md5)
                {
                    continue;

                }
            }
            //files_count = files_count + 1;

            //Debug.Log("files_count:" + files_count);
            //Debug.Log("添加到下载" + table_server_path + "保存路径" + savePath);
            DownLoadInformation di = new DownLoadInformation();
            
            di.path = table_server_path;
            di.Local_path = savePath;
            di.md5 = file.Value.md5;
            di.size = file.Value.size;
            di.type1 = false;
            di.name = file.Key;
            downLoadInformationList.Add(di);
        }
        //开始下载
        //DownLoadingScene.instance.SetProgressBar(0.02f);
        //0.98;
        DownLoadingScene.instance.SetProgressBar(0f);
        total_size = 0f;
        curSize = 0f;
        foreach (var item in downLoadInformationList)
        {
            total_size += item.size;
        }


        foreach (var item in downLoadInformationList)
        {
            while (true)
            {
                handle = HttpHelper.StartDownLoad(this, item.path, item.Local_path);
                while (!handle.isFinish)
                {
                    float size_rate = (curSize + handle.curSize) / total_size;
                    float size_rate_100 = ((curSize + handle.curSize) / total_size) * 100;
                    size_rate_100 = (float)Math.Round(size_rate_100, 1);
                    progressValueText.text = size_rate_100.ToString() + "%";
                    SetProgressBarText("正在下载更新资源" + item.name);
                    DownLoadingScene.instance.SetProgressBar(size_rate);
                    yield return null;
                }
                //下载完后校验,如果md5不一致则重新下载
                if (item.type1)
                {
                    string _md5 = GetFileHash(item.Local_path);
                    string Server_md5_ToLower = item.md5.ToLower();
                    if (Server_md5_ToLower == _md5)
                    {
                        break;
                    }
                }
                else
                {
                    string _md5 = MD5_StringUTF8(item.Local_path);
                    string _server_md5 = item.md5.ToLower();
                    //files_count = files_count + 1;
                    if (_server_md5 == _md5)
                    {
                        break;
                    }
                }
                break;
            }
            curSize += item.size;
            DownLoadingScene.instance.SetProgressBar((curSize) / total_size);
        }
        SetProgressBarText("下载完成,正在加载游戏");// "下载完成";
        DownLoadingScene.instance.SetProgressBar(1f);



        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        asyncLoad.allowSceneActivation = true;
    }

    public void SetProgressBarText(string txt)
    {
        if (null != progressMessageText)
            progressMessageText.text = txt;
    }
    

   


    void Start()
    {   //测试读取 bundle_list
        //text_obj = GameObject.Find("Text_num");

        //text_obj.GetComponent<Text>().text= text_num + "%";
        //string text_test = text_obj.GetComponent<Text>().text;
        //Debug.Log(text_test);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
        progressSlidr.value = 0f;
        StartCoroutine(UpdateFileForServer());

        
       
    }



 


    public void SetProgressBar(float v)
    {
        progressSlidr.value = v;
    }
 
    public static void Release()
    {
        if (null != instance)
            GameObject.DestroyImmediate(instance.gameObject, true);
    } 
 
   
   

    public static string GetFileHash(string filePath)//计算AB包的MD5
    {
        try
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            int len = (int)fs.Length;
            byte[] data = new byte[len];
            fs.Read(data, 0, len);
            fs.Close();
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            return System.BitConverter.ToString(result).Replace("-", "").ToLower();
        }
        catch (FileNotFoundException e)
        {
            e.ToString();
            return "";
        }
    }

    public static string MD5_StringUTF8(string filePath)   //计算文件的MD5值(UTF8)
    {
        try
        {
            string txt = System.IO.File.ReadAllText(filePath);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(txt);


            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            return System.BitConverter.ToString(result).Replace("-", "").ToLower();

        }
        catch (FileNotFoundException e)
        {
            e.ToString();
            return "1";
        }

    }



}
