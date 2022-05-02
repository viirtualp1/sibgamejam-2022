using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrolLyci : MonoBehaviour
{
    [HideInInspector] public bool mustPatrol;
    [HideInInspector] public bool mustTurn;
    private float walkSpeed = 30;

    public Rigidbody2D rb;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    // Сила отталкивания
    private float xMove = 2f;

    // Подключение инвенторя
    private Inventory inventory;
    public int i;

    // Количестово еды 
    int item = 3;

    // x Lyci
    public Transform Lyci_x;


    void Start() 
    { 
        mustPatrol = true;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update() { if (mustPatrol) Patrol(); }

    private void FixedUpdate()
    {
        if (mustPatrol) mustTurn = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
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
        // Вправо или влево отталикивание
        if (collision.gameObject.tag == "Player")
        {   
        
            if ( collision.transform.position.x <= Lyci_x.transform.position.x )
            {
                collision.transform.position = new Vector2(collision.transform.position.x - xMove, collision.transform.position.y);
            }

            if ( collision.transform.position.x >= Lyci_x.transform.position.x )
            {
                collision.transform.position = new Vector2(collision.transform.position.x + xMove, collision.transform.position.y);
            }

        }


    }
}
