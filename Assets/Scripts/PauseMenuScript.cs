using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    private bool isPaused;

    private void Start()
    {
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPause();
        }
    }

    public void onPause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
            isPaused = true;
        }
    }
    public void Resume()
    {
        onPause();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
