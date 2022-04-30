using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    // Приватные поля
    public static float speed = 3f; // Скорость движения
    public float jumpForce = 15f; // Сила прыжка

    // Ссылки
    private Rigidbody2D rb;
    public SpriteRenderer sprite;

    private bool isGrounded = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float moveInput;

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
