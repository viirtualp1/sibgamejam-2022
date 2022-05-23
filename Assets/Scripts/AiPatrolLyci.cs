using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrolLyci : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;

    [HideInInspector]
    public bool mustTurn;

    [SerializeField]
    private float walkSpeed;

    public Rigidbody2D rb;

    public Transform groundCheckPosition;

    public LayerMask groundLayer;

    [SerializeField]
    public static bool isMoveToPlayer = false;

    // Подключение инвенторя
    private Inventory inventory;

    private Transform player;

    // Сила отталкивания
    [SerializeField]
    private float xMove = 4;

    void Start()
    {
        inventory =
            GameObject
                .FindGameObjectWithTag("Player")
                .GetComponent<Inventory>();

        mustPatrol = true;
        player =
            GameObject
                .FindGameObjectWithTag("Player")
                .GetComponent<Transform>();
    }

    void Update()
    {
        if (mustPatrol && !isMoveToPlayer)
            Patrol();
        else if (isMoveToPlayer) Siren();
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
            mustTurn =
                !Physics2D
                    .OverlapCircle(groundCheckPosition.position,
                    0.5f,
                    groundLayer);
    }

    void Patrol()
    {
        if (mustTurn) Flip();
        rb.velocity =
            new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale =
            new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    private void Siren()
    {
        if (Vector2.Distance(transform.position, player.position) < 20)
        {
            if (walkSpeed > 0) Flip();

            transform.position =
                Vector2
                    .MoveTowards(transform.position,
                    player.position,
                    xMove * Time.deltaTime);
        }
        else
            isMoveToPlayer = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isMoveToPlayer)
        {
            collision.transform.position =
                new Vector2(collision.transform.position.x - xMove,
                    collision.transform.position.y);
        }
        else if (isMoveToPlayer)
        {   
            // Удаление предметов из инвенторя
            for (int i = 1; i < 7; i++)
            {
                if (inventory.isFull[i - 1])
                {
                    Destroy(GameObject
                        .Find("Inventory")
                        .transform
                        .GetChild(i)
                        .transform
                        .GetChild(0)
                        .gameObject);
                    inventory.isFull[i - 1] = false;
                }
            }
        }
    }
}
