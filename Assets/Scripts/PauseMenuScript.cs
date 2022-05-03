using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private Animator PauseOpen;
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
            PauseOpen.SetBool("PauseAnim", false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            PauseOpen.SetBool("PauseAnim", true);
            Time.timeScale = 0;
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
