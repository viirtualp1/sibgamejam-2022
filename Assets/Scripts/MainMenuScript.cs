using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] AudioSource ButtonSound;
    public void NewGame()
    {
        ButtonSound.Play();
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        ButtonSound.Play();
        Application.Quit();
    }
}
