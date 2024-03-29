using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    [SerializeField] private Animator Cat_anim;
    // Движение
    public float speed;
    public float jumpForce;
    public float currentSpeed;
    public float currentjumpForce; 
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
        currentSpeed = speed;
        currentjumpForce = jumpForce;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        if(moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        rb.AddForce(new Vector2(moveInput, 0).normalized * currentSpeed, ForceMode2D.Force);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            rb.AddForce(Vector2.up * currentjumpForce, ForceMode2D.Impulse);
            Cat_anim.SetTrigger("Jump");
        }
        else if (moveInput != 0)
        {
            Cat_anim.SetBool("Walk", true);
        }
        else 
        {
            Cat_anim.SetBool("Walk", false);
        }

    }

}
