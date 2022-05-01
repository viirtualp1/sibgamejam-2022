using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public static List<string> items;
    public string item;

    private void Start()
    {
        items = new List<string>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        items.Add(item);
        Destroy(GameObject.Find(item));
    }
}
