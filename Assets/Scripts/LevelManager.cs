using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadLevel(string name)
    {
        Debug.Log("Level load load: " + name);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }
    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Debug.Log("load next level: " + name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //level index
    }
    public void QuitRequest()
    {
        Debug.Log("Quit request");
        Application.Quit();

    }
    public void BrickDestroyed()
    {
        if (Brick.breakableCount <=0) //last brick destroyed, including double decrements
        {
            LoadNextLevel();
        }
    }
}