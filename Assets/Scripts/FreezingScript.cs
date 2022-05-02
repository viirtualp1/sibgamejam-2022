using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezingScript : MonoBehaviour
{
    [SerializeField] private Image Bar;
    [SerializeField] private float BarTime;
    [SerializeField] private GameObject FreezePanel;

    private bool onFire;

    private void Start()
    {
        onFire = false;
        Bar.fillAmount = 0;
    }

    private void Update()
    {
        if (onFire) Fire();
        else FreezingBar();

    }
    private void FreezingBar()
    {
        Bar.fillAmount += 1 - ((BarTime - Time.deltaTime) / BarTime);
        if (Bar.fillAmount == 1)
        {
            FreezePanel.SetActive(true);
            CharacterMovements.speed = 2f;
            CharacterMovements.jumpForce = 5f;
        }
    }

    private void Fire()
    {
        FreezePanel.SetActive(false);
        CharacterMovements.speed = 3f;
        CharacterMovements.jumpForce = 8f;
        Bar.fillAmount -= 1 - ((BarTime - Time.deltaTime) / BarTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)  //Добавляем тег Fire к обьекту и он становится огнем)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            onFire = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            onFire = false;
        }
    }

}