 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Reflection;

[System.Serializable]
public class MD5FileInformation
{
    public string path;
    public string md5;
    public int size;
}
[System.Serializable]
public class FTPInformation
{
    public  string ftpRoot = @"ftp://192.168.0.15/";
    public string userName = "pro3";
    public string pwd="qwer";
    public string android = "000001";
    public string ios = "000001";
    public string win = "000001";

}

public class FTPInformationWindow: EditorWindow
{

    
    public static void ShowWindow()
    {
        // Get existing open window or if none, make a new one:
        FTPInformationWindow window = (FTPInformationWindow)EditorWindow.GetWindow(typeof(FTPInformationWindow));
        
        window.Show();
    }
    private void OnLostFocus()
    {
        
        this.Focus();
    }
    private void OnGUI()
    {
         AssetbundleMarker.fTPInformation.ftpRoot = EditorGUILayout.TextField("版本号", AssetbundleMarker.fTPInformation.ftpRoot);
        AssetbundleMarker.type = (PublicType)EditorGUILayout.EnumPopup("打包类型", AssetbundleMarker.type);
        
        if (AssetbundleMarker.type == PublicType.Android)
        {
            AssetbundleMarker.fTPInformation.android = EditorGUILayout.TextField("版本号", AssetbundleMarker.fTPInformation.android);
        }
        else if (AssetbundleMarker.type == PublicType.IOS)
        {
            AssetbundleMarker.fTPInformation.ios = EditorGUILayout.TextField("版本号", AssetbundleMarker.fTPInformation.ios);
        }
        else  
        {
            AssetbundleMarker.fTPInformation.win = EditorGUILayout.TextField("版本号", AssetbundleMarker.fTPInformation.win);
        }
        AssetbundleMarker.fTPInformation.userName = EditorGUILayout.TextField("用户名", AssetbundleMarker.fTPInformation.userName);
        AssetbundleMarker.fTPInformation.pwd = EditorGUILayout.PasswordField("密码", AssetbundleMarker.fTPInformation.pwd);
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("确定"))
        {
            System.IO.File.WriteAllText("ftpConfig.json",JsonConvert.SerializeObject(AssetbundleMarker.fTPInformation));
            this.Close();
            if (AssetbundleMarker.type == PublicType.Android)
            {
                AssetbundleMarker.PackAndroid();
                //AssetbundleMarker.UpdateFTP();
            }
           
        }
        if (GUILayout.Button("取消"))
        {
             
            this.Close();
             

        }
        EditorGUILayout.EndHorizontal();
    }
}
public enum PublicType
{
    Android,
    IOS,
    WIN,
}
public class AssetbundleMarker
{

    public static PublicType type = PublicType.Android;
    public static FTPInformation fTPInformation;

    [MenuItem("工具/Assetbundle/打包AssetBundle")]
    public static void ModifyFTPInformation()
    {

        if (System.IO.File.Exists("ftpConfig.json"))
        {
            AssetbundleMarker.fTPInformation = JsonConvert.DeserializeObject<FTPInformation>(System.IO.File.ReadAllText("ftpConfig.json"));
        }
        if (null == AssetbundleMarker.fTPInformation)
        {
            AssetbundleMarker.fTPInformation = new FTPInformation();
        }
        FTPInformationWindow.ShowWindow();

    }
    public static string GetFileHash(string filePath,out int size)
    {
        try
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            int len = (int)fs.Length;
            byte[] data = new byte[len];
            fs.Read(data, 0, len);
            fs.Close();
            size = len;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            return System.BitConverter.ToString(result).Replace("-", "");
        }
        catch (FileNotFoundException e)
        {
            e.ToString();
            size = 0;
            return "";
        }
    }

    class AssetBundleInformation
    {
        public string path;
        public string Pattern;
        public int type;

    }

    static public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);

    }

    [MenuItem("工具/Assetbundle/标记assetbunele名", false, 351)]
    static void nameAssetBundle()
    {
        ClearLog();
        string filePattern = "";
        ClearAssetBundleName();
        string json = System.IO.File.ReadAllText(@"./AssetBundleData.json");
        List<AssetBundleInformation> list = JsonConvert.DeserializeObject<List<AssetBundleInformation>>(json);
        foreach (var v in list)
        {
            switch (v.type)
            {
                case 0://all in one
                    {
                        string root = @"Assets\" + v.path;
                        if (!System.IO.Directory.Exists(root))
                        {
                            break;
                        }
                        List<string> files = DirHelper.GetAllFiles(root, v.Pattern, ".", ".meta");
                        string bundleName = DirHelper.GetBundleName(root, "Assets");
                        foreach (string path in files)
                        {
                            if (path.EndsWith(".cs"))
                                continue;
                            EditorUtility.DisplayProgressBar("标记assetBundle", path, 0f);
                            string bundleFileName = DirHelper.GetRelactionPathEditor(path, "Assets");
                            var ip = AssetImporter.GetAtPath(path);
                            if (null != ip)
                            {
                                ip.SetAssetBundleNameAndVariant(bundleName, filePattern);
                                EditorUtility.UnloadUnusedAssetsImmediate();
                            }

                        }
                    }
                    break;

                case 1://all child as one
                    {
                        string path0 = @"Assets\" + v.path;
                        if (!System.IO.Directory.Exists(path0))
                        {
                            break;
                        }
                        string[] dirs = System.IO.Directory.GetDirectories(path0);
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            string root = dirs[i];
                            string bundleName = DirHelper.GetBundleName(root, "Assets");
                            List<string> files = DirHelper.GetAllFiles(root, v.Pattern, ".");
                            foreach (string path in files)
                            {
                                if (path.EndsWith(".cs"))
                                    continue;
                                EditorUtility.DisplayProgressBar("标记assetBundle", path, 0f);
                                string bundleFileName = DirHelper.GetRelactionPathEditor(path, "Assets");
                                var ip = AssetImporter.GetAtPath(path);
                                if (null != ip)
                                {
                                    ip.SetAssetBundleNameAndVariant(bundleName, filePattern);
                                    EditorUtility.UnloadUnusedAssetsImmediate();
                                }

                            }
                        }
                    }
                    break;

                case 2://找到该目录, 并把该目录下所有符合匹配的文件分别打包成一个单独的AB
                    {
                        string root = @"Assets\" + v.path;
                        if (!System.IO.Directory.Exists(root))
                        {
                            break;
                        }
                        string[] files = System.IO.Directory.GetFiles(root, v.Pattern);
                        string fullPath2 = System.IO.Path.GetFullPath(".");
                        for (int i = 0; i < files.Length; i++)
                        {
                            string path = files[i];
                            if (path.EndsWith(".cs"))
                                continue;
                            EditorUtility.DisplayProgressBar("标记assetBundle", path, 0f);
                            string fn = System.IO.Path.GetFileNameWithoutExtension(path);
                            string bundleName = DirHelper.GetBundleName(root, "Assets") + "@" + fn; ;
                            string bundleFileName = DirHelper.GetRelactionPathEditor(path, "Assets");


                            var ip = AssetImporter.GetAtPath(path);
                            if (null != ip)
                            {
                                ip.SetAssetBundleNameAndVariant(bundleName, filePattern);
                                EditorUtility.UnloadUnusedAssetsImmediate();
                            }
                        }
                        break;
                    }
                case 3://
                    {
                        //当前及子文件夹下所有文件都是单独一个。
                        string root = @"Assets\" + v.path;
                        {
                            if (!System.IO.Directory.Exists(root))
                            {
                                break;
                            }
                            List<string> files = DirHelper.GetAllFiles(root, v.Pattern, ".");
                            string fullPath2 = System.IO.Path.GetFullPath(".");
                            for (int i = 0; i < files.Count; i++)
                            {
                                string path = files[i];
                                if (path.EndsWith(".cs"))
                                    continue;
                                EditorUtility.DisplayProgressBar("标记assetBundle", path, 0f);
                                string fn = System.IO.Path.GetFileNameWithoutExtension(path);
                                string bundleName = DirHelper.GetBundleName(root, "Assets") + "@" + fn; ;
                                string bundleFileName = DirHelper.GetRelactionPathEditor(path, "Assets");
                                //Debug.LogError(path);


                                var ip = AssetImporter.GetAtPath(path);
                                if (null != ip)
                                {
                                    ip.SetAssetBundleNameAndVariant(bundleName, filePattern);
                                    EditorUtility.UnloadUnusedAssetsImmediate();
                                }
                            }
                            break;
                        }
                    }
            }
        }
        {

            Dictionary<string, string> alls = new Dictionary<string, string>();
            foreach (var assetBundleName in AssetDatabase.GetAllAssetBundleNames())
            {
                foreach (var assetPathAndName in AssetDatabase.GetAssetPathsFromAssetBundle(assetBundleName))
                {
                    alls[assetPathAndName.ToLower()] = assetBundleName;
                }
            }
            string allText = JsonConvert.SerializeObject(alls);
            string path = "assets/allfiles.json";
            System.IO.File.WriteAllText(path, allText);
            AssetDatabase.ImportAsset(path);
            var ip = AssetImporter.GetAtPath(path);
            if (null != ip)
            {
                ip.SetAssetBundleNameAndVariant("filelist", filePattern);
                EditorUtility.UnloadUnusedAssetsImmediate();
            }
        }
    }

    /// <summary>
    /// 清理之前设置的bundleName
    /// </summary>
    public static void ClearAssetBundleName()
    {
        string[] bundleNames = AssetDatabase.GetAllAssetBundleNames();
        for (int i = 0; i < bundleNames.Length; i++)
        {
            AssetDatabase.RemoveAssetBundleName(bundleNames[i], true);
        }
    }


    static void ImportFolder(string path = @"Assets\table", string searchPattern = "*.json")
    {
        string realPath = Application.dataPath;
        realPath = realPath.Remove(realPath.Length - 6);
        string selectedPath = realPath + path;
        string[] fileEntries = Directory.GetFiles(selectedPath, searchPattern, SearchOption.AllDirectories);
        for (int i = 0; i < fileEntries.Length; i++)
        {
            string file = fileEntries[i];
            file = file.Replace("\\", "/");
            file = file.Remove(0, realPath.Length);
            AssetDatabase.ImportAsset(file);
        }
    }

    public static void PackAndroid()
    {
        type = PublicType.Android;
        EditorUtility.DisplayProgressBar("打包assetBundle", "标记assetBundle", 0f);
        ImportFolder();
        AssetDatabase.Refresh();
        BuildTarget target = BuildTarget.Android;
        nameAssetBundle();
        EditorUtility.ClearProgressBar();
        BuildBundle(target);
        MakeMd5List(target);
        UpdateFTP();
        EditorUtility.DisplayDialog("打包完毕", "打包完毕", "确定");
    }

    public static void UpdateFTP()
    {
        string baseDir = "";
        string fileDir = "";
        string version = "";
        string bundleDir = "";
        if (type == PublicType.IOS)
        {
            baseDir += @"IOS";
            fileDir = baseDir +"/"+ fTPInformation.ios;
            version = fTPInformation.ios;
            bundleDir = GetBuildDir(BuildTarget.iOS);
        }
        else if (type == PublicType.WIN)
        {
            baseDir += @"Win"   ;
            fileDir = baseDir + "/" + fTPInformation.win;
            version = fTPInformation.win;
            bundleDir = GetBuildDir(BuildTarget.StandaloneWindows);
        }
        else
        {
            baseDir += @"Android"  ;
            fileDir = baseDir + "/" + fTPInformation.android;
            version = fTPInformation.android;
            bundleDir = GetBuildDir(BuildTarget.Android);
        }
        EditorUtility.DisplayProgressBar("上传文件", "监测目录", 0f);
        FtpHelper ftp = new FtpHelper(fTPInformation.ftpRoot, fTPInformation.userName, fTPInformation.pwd);
        ftp.ChangeDir(baseDir);

        if (ftp.DirectoryExist(version))
        {
            ftp.ChangeDir(fileDir);
            string[] files = ftp.GetFileList("*.*");
            if (files.Length > 0)
            {
                float delta = 0.2f/ files.Length;
                float total = 0f;
                foreach (string f in files)
                {
                    EditorUtility.DisplayProgressBar("上传文件", "监测目录", total);
                    ftp.Delete(f);
                    total += delta;
                }
            }
        }
        else
        {
            ftp.MakeDir(version);
        }
        ftp.ChangeDir(fileDir);
        {
            string[] assetBundles = System.IO.Directory.GetFiles(bundleDir);
            float delta = 0.8f / assetBundles.Length;
            float total = 0.2f;
            foreach (string file in assetBundles)
            {
                EditorUtility.DisplayProgressBar("上传文件", "上传" + file+"中...", total);
                ftp.Upload(file);
                total += delta;
            }
        }
        EditorUtility.ClearProgressBar();

    }

    [MenuItem("工具/Assetbundle/更新美术资源", false, 351)]
    public static void UpdateProject()
    {
        CallCmd("update.bat");
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
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 6) + "\\"+ cmd;
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

     

    public static string outDirect = "assetBundles";
    public static string GetBuildDir(BuildTarget target)
    {
        System.IO.Directory.CreateDirectory(outDirect);
        string path = outDirect +@"\"+ target.ToString();
        
        return path;
    }
    
    public static void BuildBundle(BuildTarget target)
    {
        // 清理之前设置过的bundleName
        string path = GetBuildDir(target);
        DirHelper.DeleteSrcFolder(path);
        System.IO.Directory.CreateDirectory(path);
        Debug.Log("build for "+ target.ToString());
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, target);
        AssetDatabase.Refresh();

        //+@"\"+ target.ToString();
        /*if (target == BuildTarget.Android)
        {
            string targetPath = "D:/MyWorkspaces/client/AndroidClient/Assets/StreamingAssets/" + target.ToString();
            DirHelper.DeleteSrcFolder(targetPath);
            System.IO.Directory.CreateDirectory(targetPath);
            DirHelper.CopyDirectory(path, targetPath);
        }*/

    }
     
    public static void MakeMd5List(BuildTarget target)
    {
        // 清理之前设置过的bundleName
        string path = Path.GetFullPath(GetBuildDir(target));
        int index0 = path.Length;


        EditorUtility.DisplayProgressBar("打包assetBundle", "创建md5", 0f);
        
        string[]  files = System.IO.Directory.GetFiles(path,"*.*", SearchOption.AllDirectories);
        List<MD5FileInformation> md5s = new List<MD5FileInformation>();
        if (files.Length > 0)
        {
            float total = 0f;
            float detal = 1f / files.Length;
            for (int i = 0; i < files.Length; i++)
            {
                string _path = Path.GetFullPath(files[i]);
                if (_path.EndsWith(".version"))
                {
                    continue;
                }
                EditorUtility.DisplayProgressBar("创建md5", _path, total);
                //fileList += _path.Substring(index0 + 1)+"?"+ GetFileHash(_path) +"\n";
                MD5FileInformation m = new MD5FileInformation();
                m.path = _path.Substring(index0 + 1);
                m.md5 = GetFileHash(_path,out m.size);
      
                md5s.Add(m);

                total += detal;
            }
        }
        
        string outPath = path + @"\files.version";
        string json = JsonConvert.SerializeObject(md5s);
        Debug.Log(outPath);
        System.IO.File.WriteAllText(outPath, json);

    }
}
