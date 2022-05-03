using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    public GameObject spritePartOfSandwich;

    private GameObject muzhyk;
    private GameObject cheeseMain;
    private GameObject cheese;

    [SerializeField] private Animator Golub_anim;

    private string[] partsOfSandwich = { "cheese", "baton", "hleb", "salad", "sausage", "mayonnaise" };

    private void Start()
    {
        cheeseMain = GameObject.Find("CheeseMain");
        cheese = cheeseMain.transform.GetChild(0).gameObject;

        muzhyk = GameObject.Find("muzhyk");
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
                    Debug.Log(Inventory.isFull[i]);
                    if (!Inventory.isFull[i] && (inventory.slots[i].gameObject.tag == partsOfSandwich[j] && inventory.slots[i].gameObject.tag == spritePartOfSandwich.name))
                    {
                        if (spritePartOfSandwich.name == "sausage")
                        {
                            AiPatrolLyci.isMoveToPlayer = true;   
                            muzhyk.SetActive(false);
                            
                            cheese.GetComponent<SpriteRenderer>().enabled = true;
                            cheese.GetComponent<BoxCollider2D>().enabled = true;
                        }

                        if (spritePartOfSandwich.name == "baton") Golub_anim.SetBool("PickUpBread", true);

                        Debug.Log('2');
                        Inventory.isFull[i] = true;
                        Instantiate(slotButton, inventory.slots[i].transform);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
