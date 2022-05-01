using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private GameObject EndPanel;

    [SerializeField] private GameObject[] Items;

    [SerializeField] private bool[] isHaveItems;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndGame"))
        {
            EndPanel.SetActive(true);
            for (int i = 0; i < 6; i++)
            {
                if (isHaveItems[i]) Items[i].SetActive(true);
                else Items[i].SetActive(false);
            }
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
