using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DirHelper  
{
    /// <summary>
    /// 获取子目录的文件
    /// </summary>
    /// <param name="fullPath"></param>
    /// <returns></returns>
    public static List<string> GetAllFiles(string path, string Pattern, string parent,string notUsed ="")
    {
        string []  pattern = Pattern.Split('|');
        string fullPath = System.IO.Path.GetFullPath(path);
        List<string> dirList = new List<string>();
        if (!System.IO.Directory.Exists(fullPath))
        {
            return dirList;
        }
        string fullPath2 = System.IO.Path.GetFullPath(parent);
       
        int root = fullPath2.Length + 1;
        for (int j = 0; j < pattern.Length; j++)
        {
            if (pattern[j] == notUsed)
                continue;
            string[] files = System.IO.Directory.GetFiles(fullPath, pattern[j], System.IO.SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; ++i)
            {
                dirList.Add(files[i].Substring(root) );
            }
        }
        
        return dirList;
    }
    public static string GetRelactionPathEditor(string path,string root)
    {
        string fullPath = System.IO.Path.GetFullPath(root);
        string path1 = System.IO.Path.GetFullPath(path);
        return path1.Substring(fullPath.Length +1);
    }

    public static string GetBundleName(string path, string root)
    {
       
        string path1 = GetRelactionPathEditor(path, root);
        path1 = path1.Replace('/','$');
        path1 = path1.Replace('\\', '$');
        return path1;
    }

    public static void DeleteSrcFolder(string file)
    {
        try
        {
            System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file);

            fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;
            //去除文件的只读属性
            System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);
            //判断文件夹是否还存在
            if (Directory.Exists(file))
            {
                foreach (string f in Directory.GetFileSystemEntries(file))
                {
                    if (File.Exists(f))
                    {
                        //如果有子文件删除文件
                        File.Delete(f);
                    }
                    else
                    {
                        //循环递归删除子文件夹 
                        DeleteSrcFolder1(f);
                    }
                }
                //删除空文件夹
                //Directory.Delete(file);
            }
        }
        catch (System.Exception e)
        {
            e.ToString();
        }

        
    }

    public static void DeleteSrcFolder1(string file)
    {
        //去除文件夹和子文件的只读属性
        //去除文件夹的只读属性
        System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file);
        fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;
        //去除文件的只读属性
        System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);
        //判断文件夹是否还存在
        if (Directory.Exists(file))
        {
            foreach (string f in Directory.GetFileSystemEntries(file))
            {
                if (File.Exists(f))
                {
                    //如果有子文件删除文件
                    File.Delete(f);
                }
                else
                {
                    //循环递归删除子文件夹 
                    DeleteSrcFolder1(f);
                }
            }
            //删除空文件夹
            Directory.Delete(file);
        }
    }


    public static void CopyDirectory(string srcPath, string destPath)
    {
        try
        {
            DirectoryInfo dir = new DirectoryInfo(srcPath);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
            foreach (FileSystemInfo i in fileinfo)
            {
                if (i is DirectoryInfo)     //判断是否文件夹
                {
                    if (!Directory.Exists(destPath + "/" + i.Name))
                    {
                        Directory.CreateDirectory(destPath + "/" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                    }
                    CopyDirectory(i.FullName, destPath + "/" + i.Name);    //递归调用复制子文件夹
                }
                else
                {
                    File.Copy(i.FullName, destPath + "/" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                }
            }
        }
        catch (Exception e)
        {
            e.ToString();
        }
    }



}
