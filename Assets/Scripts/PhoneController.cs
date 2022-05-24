using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    [SerializeField] private Animator Cat_anim;
    // Движение
    public float speed;
    public float jumpForce = 15f;
    public float currentSpeed;
    public float currentjumpForce; 
    private float moveInput;
	  public float normalSpeed = 450f;

    // Ссылки на игрока
    private Rigidbody2D rb;
    public SpriteRenderer sprite;

    // Поля для реализации прыжка
    private bool isGrounded = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

	private float deltaX;
	private BoxCollider2D _box;

    public void MoveRight() { speed = normalSpeed; Cat_anim.SetBool("Walk", true); }

	public void ButtonUp() { speed = 0; Cat_anim.SetBool("Walk", false); }

	public void MoveLeft() { speed = -normalSpeed; Cat_anim.SetBool("Walk", true); }

    void Awake() {
        currentSpeed = speed;
        currentjumpForce = jumpForce;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
		deltaX = speed * Time.fixedDeltaTime;
		Vector2 movement = new Vector2(deltaX, rb.velocity.y);
		rb.velocity = movement;
		
		if(!Mathf.Approximately(deltaX,0))
			transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
	}

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }

    public void Jump()
    {
		if (isGrounded)
        {
            rb.AddForce(Vector2.up * currentjumpForce, ForceMode2D.Impulse);
            Cat_anim.SetTrigger("Jump");
        }
	}
}
