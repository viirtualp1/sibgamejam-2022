using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Старая реализация
            // for (int i = 0; i < inventory.slots.Length; i++)
            // {
            //     if (inventory.isFull[i] == false)
            //     {
            //         Debug.Log(slotButton.name);
            //         inventory.isFull[i] = true;
            //         Instantiate(slotButton, inventory.slots[i].transform);
            //         Destroy(gameObject);
            //         break;
            //     }
            // }

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Debug.Log(slotButton.name);
                    inventory.isFull[i] = true;

                    if(slotButton.name == "cucumber 1")
                    {
                        Instantiate(slotButton, inventory.slots[2].transform);
                        Destroy(gameObject);
                    }

                    if(slotButton.name == "fromButton")
                    {
                        Instantiate(slotButton, inventory.slots[1].transform);
                        Destroy(gameObject);
                    }

                    if(slotButton.name == "tomatoButton")
                    {
                        Instantiate(slotButton, inventory.slots[0].transform);
                        Destroy(gameObject);
                    }
                    
                    break;
                }
            }

        }
    }
}
