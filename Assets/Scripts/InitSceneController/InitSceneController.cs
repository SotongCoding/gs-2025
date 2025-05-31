using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitSceneController : MonoBehaviour
{
    private void Start() 
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("GameplayScene");
    }
}
