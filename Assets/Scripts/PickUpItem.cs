using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    //Старый способ реализации
    //public static List<string> items;
    //public string item;

    private Inventory inventory;
    public int i;

    private void Start()
    {
        // Старый способ
        //items = new List<string>();

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            Inventory.isFull[i] = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {   
        Debug.Log(inventory.slots[i].transform);
        //GameObject.Destroy();
        // Старый способ
        // items.Add(item);
        // Destroy(GameObject.Find(item));
    }
}
