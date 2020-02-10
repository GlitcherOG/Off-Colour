using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void Start()
    {
        isPaused = true;
        TogglePause();
    }
    public GameObject SettingsGO;
    public bool gameEnded = false;
    public bool isPaused = false;
    public GameObject _pauseMenu;
    public static bool isDead = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if (isDead == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None; // lock the mouse cursor
            Cursor.visible = true;
            _pauseMenu.SetActive(true);
            isPaused = true;
        }
        if (Setting.SettingsOpen)
        {
            SettingsGO.SetActive(true);
        }
        else if (!Setting.SettingsOpen)
        {
            SettingsGO.SetActive(false);
        }
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; // lock the mouse cursor
            Cursor.visible = false;
            isPaused = false;
            return;

        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None; // lock the mouse cursor
            Cursor.visible = true;
            _pauseMenu.SetActive(true);
            isPaused = true;
            return;
        }
    }

    public void GameOver()
    {
        gameEnded = true;
    }

    //Reloads the Current Level

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isDead = false;
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None; // lock the mouse cursor
        Cursor.visible = false;
        isPaused = false;

    }
    //
    //create a function to move to next scene by loading the activeScene +1
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        isPaused = true;
        TogglePause();
    }
    //create a function to move to previous scene by loading the activeScene - 1
    public void PrevLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    //create a function to load a scene by loading the activeScene of the levelID int
    public void SwitchLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }
    public void OpenSettings()
    {

        /*/switch (MenuSelect)
        {
            case menuSelect.Play:
                break;
            case
            /*/

        Setting.SettingsOpen = !Setting.SettingsOpen;


    }
    //create an update function that make SettingsGO option switch between active and inactive based on whether SettingsOpen is true or false
    
    //create a function to quite the game by unityEditor isPlaying false and calling a inbuilt function to make the application quit
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }



}
