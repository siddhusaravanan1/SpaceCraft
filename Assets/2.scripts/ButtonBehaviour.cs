using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonBehaviour : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject gameOverPanel;
    public void Play()
    {
        SceneManager.LoadScene("BaseLayer");
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        gameOverPanel.SetActive(false);
    }
}
