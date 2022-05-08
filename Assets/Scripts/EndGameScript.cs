using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private GameObject EndPanel;

    [SerializeField] private GameObject[] Items;

    [SerializeField] private int isHaveItems;

    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndGame"))
        {
            EndPanel.SetActive(true);
            GameObject.Find("controlMobile").SetActive(false);
            for (int i = 0; i < 6; i++)
            {
                if (inventory.isFull[i])
                {
                    Items[i].SetActive(true);
                    isHaveItems++;
                } 
                else Items[i].SetActive(false);
            }

            StartCoroutine(DelayTime());
        }
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(isHaveItems > 0 ? 3 : 4);
    }
    // public void Replay()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
    // public void Exit()
    // {
    //     Application.Quit();
    // }
}
