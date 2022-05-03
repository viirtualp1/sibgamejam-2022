using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
    [HideInInspector] public bool mustPatrol;
    [HideInInspector] public bool mustTurn;
    private float walkSpeed = 30;

    public Rigidbody2D rb;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    // Подключение инвенторя
    private Inventory inventory;
    private int i;

    // Количестово еды 
    int item = 6;

    void Start() 
    { 
        mustPatrol = true; 
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update() { if (mustPatrol) Patrol(); }

    private void FixedUpdate()
    {
        if (mustPatrol) mustTurn = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.5f, groundLayer);
    }

    void Patrol()
    {
        if (mustTurn) Flip();
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.tag == "Player") PickUpItem.items.RemoveAt(PickUpItem.items.Count - 1);
         if (collision.gameObject.tag == "Player")
         {

            if (transform.childCount <= 0)
            {
                inventory.isFull[i] = false;
            }
            
            if(item > 0)
            {   
                // Полноное удаление
                // for (int i = 2; i <= inventory.slots.Length; i--)
                // {
                //     Destroy(GameObject.Find("Inventory").transform.GetChild(i).transform.GetChild(0).gameObject);
                // }
                Debug.Log(item);
                Debug.Log(GameObject.Find("Inventory").transform.GetChild(item));
                item = item - 1;
                Destroy(GameObject.Find("Inventory").transform.GetChild(item).transform.GetChild(0).gameObject);
            }
            // Для рейтинга
            //Debug.Log(GameObject.Find("Inventory").transform.GetChild(1).transform.GetChild(0).gameObject);
        }


    }
}
