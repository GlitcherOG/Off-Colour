using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance = null;
    //Make it so this script is accesable anywhere in the scene 
    void Awake()
    {
        Instance = this;
    }
    #endregion
    public bool gameEnded = false;
    public bool isPaused = false;
    public GameObject _pauseMenu;
    public GameObject gameOver;
    public GameObject pause;
    public ScoreManager score;
    public Text distance;
    public bool isDead = false;
    public void Start()
    {
        Time.timeScale = 1;
        pause.SetActive(true);
        gameOver.SetActive(false);
        _pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isDead)
        {
            TogglePause();
        }
        if (isDead == true)
        {
            Time.timeScale = 0;
            isPaused = true;
            distance.text = ScoreManager.distance.ToString();
            _pauseMenu.SetActive(true);
            gameOver.SetActive(true);
            pause.SetActive(false);
            score.save();
        }
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
            isPaused = false;
            return;
        }
        else
        {
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
            isPaused = true;
            return;
        }
    }
}
