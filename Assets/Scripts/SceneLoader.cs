using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static int SceneNumber = 0;
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
        SceneNumber++;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        SceneNumber = 1;
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
