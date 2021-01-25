using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToMainScene : MonoBehaviour
{

    public float deltaTime = 3f;
    void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject g =  GameObject.Find("LancherCanvas");
        GameObject.DontDestroyOnLoad(g);
 
        Invoke("LoadMainScene", deltaTime);
        
    }

    
}
