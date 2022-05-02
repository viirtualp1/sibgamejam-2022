using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezingScript : MonoBehaviour
{
    [SerializeField] private Image Bar;
    [SerializeField] private float BarTime;
    [SerializeField] private GameObject FreezePanel;
    [SerializeField] private CharacterMovements characterMovements;

    [SerializeField] private float FreezeSpeed;
    [SerializeField] private float FreezePower;

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
            characterMovements.currentSpeed = FreezeSpeed;
            characterMovements.currentjumpForce = FreezePower;
        }
    }

    private void Fire()
    {
        FreezePanel.SetActive(false);
        characterMovements.currentSpeed = characterMovements.speed;
        characterMovements.currentjumpForce = characterMovements.jumpForce;
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