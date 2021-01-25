using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHelper  
{
    
    // Start is called before the first frame update
    public static Texture2D GetScreen(  )
    {
        Texture2D t = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);//需要正确设置好图片保存格式
        t.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);//按照设定区域读取像素;注意是以左下角为原点读取
        t.Apply();
        return t;
    }
    public static RenderTexture GetMainScreen(float scale = 1.0f)
    {
        Camera cam = Common.GetMainCamera();
        int oldMark = cam.cullingMask;

        cam.cullingMask &= ~(1 << 5); // 关闭层UI
        int width = (int)(scale*Screen.width );
        int height = (int)(scale * Screen.height);

        RenderTexture rt = new RenderTexture( width , height ,24);
        cam.targetTexture = rt;
        cam.Render();
        cam.targetTexture = null;
        cam.cullingMask = oldMark;
        return rt;
    }
   
}
