using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezingScript : MonoBehaviour
{
    [SerializeField] private Image Bar;
    [SerializeField] private float BarTime;
    [SerializeField] private CharacterMovements characterMovements;
    [SerializeField] private PhoneController phoneController;

    [SerializeField] private float FreezeSpeed;
    [SerializeField] private float FreezePower;

    [SerializeField] private ParticleSystem[] snow;
    [SerializeField] private GameObject[] BigSnow;
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
            // for pc movement
            characterMovements.currentSpeed = FreezeSpeed;
            characterMovements.currentjumpForce = FreezePower;
            
            // for mobile movement
            phoneController.normalSpeed = FreezeSpeed;
            phoneController.currentjumpForce = FreezePower;
            
            BigSnow[0].SetActive(true);
            BigSnow[1].SetActive(true);
        }
    }

    private void Fire()
    {
        // for pc movement
        characterMovements.currentSpeed = characterMovements.speed;
        characterMovements.currentjumpForce = characterMovements.jumpForce;

        // for mobile movement
        phoneController.normalSpeed = 300;
        phoneController.currentjumpForce = phoneController.jumpForce;

        Bar.fillAmount -= 2*(1 - ((BarTime - Time.deltaTime) / BarTime));
        BigSnow[0].SetActive(false);
        BigSnow[1].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)  //��������� ��� Fire � ������� � �� ���������� �����)
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