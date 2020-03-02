using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region Singleton
    public static MenuManager Instance = null;
    //Make it so this script is accesable anywhere in the scene 
    void Start()
    {
        Instance = this;
    }
    #endregion
    //Restarts current Level
    public void Restart()
    {
        GameManager.Instance.isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    //Loads next level
    public void NextLevel()
    {
        GameManager.Instance.isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
    //Loads Previous Level
    public void Prevlevel()
    {
        GameManager.Instance.isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Single);
    }
    public void ChangeLevel(int index)
    {
        GameManager.Instance.isDead = false;
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }
    //create a function to quite the game by unityEditor isPlaying false and calling a inbuilt function to make the application quit
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }





}
