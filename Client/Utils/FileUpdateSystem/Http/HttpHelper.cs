using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class HttpHandle
{
    public bool isFinish = false;

    public bool HasError = false;
    public int totalSize = 0;
    public int curSize = 0;
    public System.Exception error;
    public HttpStatusCode statusCode;
}

public class HttpHelper : MonoBehaviour
{
    public static HttpHandle StartDownLoad(MonoBehaviour root,string url, string path)
    {
        HttpHandle handle = new HttpHandle();
        handle.isFinish = false;
        root.StartCoroutine(HttpDownloadFile(url, path, handle));
        return handle;
    }

    public static IEnumerator HttpDownloadFile(string url, string path, HttpHandle handle)   //从Http下载文件
    {
        HttpWebRequest request = null;
        HttpWebResponse response = null;
        Stream responseStream = null;
        Stream stream = null;
        handle.HasError = false;
        int size = 0;
        // 设置参数string
        byte[] bArr = new byte[1024*128];
        try
        {
            request = WebRequest.Create(url) as HttpWebRequest;
            //发送请求并获取相应回应数据
            response = request.GetResponse() as HttpWebResponse;
            handle.statusCode = response.StatusCode;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                handle.totalSize = (int)response.ContentLength;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                responseStream = response.GetResponseStream();

                //创建本地文件写入流
                stream = new FileStream(path, FileMode.Create);
                //stream.Dispose();//防止错误IOException: Sharing violation on path 的解决方案
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            else
            {
                size = 0;
                handle.isFinish = true;
                handle.error = null;
                handle.HasError = true;
            }

            
           
        }
        catch (System.Exception e)
        {
            handle.isFinish = true;
            handle.error = e;
            handle.HasError = true;
        }

        while (size > 0)
        {
            stream.Write(bArr, 0, size);
            handle.curSize += size;
            size = responseStream.Read(bArr, 0, (int)bArr.Length);
            yield return null;
        }
        
        if (null != stream)
            stream.Close();
        if (null != responseStream)
            responseStream.Close();
        handle.isFinish = true;

    }

}
