using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    public GameObject spritePartOfSandwich;

    private string[] partsOfSandwich = { "cheese", "baton", "salad", "sausage", "mayonnaise" };

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
                    if (!inventory.isFull[i] && (inventory.slots[i].gameObject.tag == spritePartOfSandwich.name))
                    {
                        inventory.isFull[i] = true;
                        Instantiate(spritePartOfSandwich, inventory.slots[i].transform);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
