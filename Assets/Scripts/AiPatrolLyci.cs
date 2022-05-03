using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrolLyci : MonoBehaviour
{
    [HideInInspector] public bool mustPatrol;
    [HideInInspector] public bool mustTurn;
    private float walkSpeed = 120;

    public Rigidbody2D rb;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    [SerializeField] public static bool isMoveToPlayer = false;
    
    private Transform player;

    // Сила отталкивания
    private float xMove = 6f;

    void Start() { 
        mustPatrol = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() {
        if (mustPatrol && !isMoveToPlayer) Patrol();
        else if (isMoveToPlayer) Siren();
    }

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

    private void Siren()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, xMove * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.transform.position = new Vector2(collision.transform.position.x - xMove, collision.transform.position.y);
    }
}
