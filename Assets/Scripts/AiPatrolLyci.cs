using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrolLyci : MonoBehaviour
{

    [HideInInspector] public bool mustPatrol;
    [HideInInspector] public bool mustTurn;
    [SerializeField] private float walkSpeed;
    public Rigidbody2D rb;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    [SerializeField] public static bool isMoveToPlayer = false;
    
    private Transform player;

    // Сила отталкивания
    [SerializeField] private float xMove;

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
        if (Vector2.Distance(transform.position, player.position) < 20)
        {
            if (walkSpeed > 0) Flip();

            transform.position = Vector2.MoveTowards(transform.position, player.position, xMove * Time.deltaTime);
        }
        else
            isMoveToPlayer = false;
    }
}
