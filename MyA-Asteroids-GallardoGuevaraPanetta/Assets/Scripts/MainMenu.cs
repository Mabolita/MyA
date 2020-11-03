using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource audioo;
    public int _currentscene;

    private void Awake()
    {
            EventManager.Instance.SubEvent("LoseScene", LoseScene);
       
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        _currentscene = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoseScene(params object[] parameters)
    {
        SceneManager.LoadScene(2);
        _currentscene = 2;
    }
    public void Credits()
    {
        SceneManager.LoadScene(3);
        _currentscene = 3;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (GameIsPaused)
            {
                Resume();
                Debug.Log("pausa");
            }
            else
            {
                Pause();
            }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        audioo.Play();
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        audioo.Pause();
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
