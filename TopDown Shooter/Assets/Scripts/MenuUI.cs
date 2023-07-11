using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameplayUI;

    public InputHandler inputHandler;

    private void Start()
    {
        MyCode.GameManager.GetInstance().OnGameOverAction += gameOver;
    }
    private void OnEnable()
    {
        inputHandler.OnPauseAction += pauseGame;
    }

    private void OnDisable()
    {
        inputHandler.OnPauseAction -= pauseGame;
    }

    public void startGame()
    {
        gameplayUI.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        MyCode.GameManager.GetInstance().pauseGame();
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        MyCode.GameManager.GetInstance().resumeGame();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void gameOver()
    {
        gameOverMenu.SetActive(true);
        gameplayUI.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
