using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    public GameObject spritePartOfSandwich;

    private string[] partsOfSandwich = { "cheese", "baton", "hleb", "salad", "sausage", "mayonnaise" };

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                for (int j = 0; j < partsOfSandwich.Length; j++)
                {
                    Debug.Log(inventory.isFull[i]);
                    if (!inventory.isFull[i] && (inventory.slots[i].gameObject.tag == partsOfSandwich[j] && inventory.slots[i].gameObject.tag == spritePartOfSandwich.name))
                    {   
                        Debug.Log('2');
                        inventory.isFull[i] = true;
                        Instantiate(slotButton, inventory.slots[i].transform);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
