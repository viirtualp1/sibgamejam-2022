using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    // Движение
    public static float speed = 3f; 
    public static float jumpForce = 10f; 
    private float moveInput;

    // Ссылки на игрока
    private Rigidbody2D rb;
    public SpriteRenderer sprite;

    // Поля для реализации прыжка
    private bool isGrounded = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) rb.velocity = Vector2.up * jumpForce;
    }
}
