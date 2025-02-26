using UnityEngine;

public class RunningMan : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool movingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Check if the Animator has the parameter "isMovingLeft"
        //if (!animator.HasParameter("isMovingLeft"))
        //{
        //    Debug.LogError("Animator does not have a parameter named 'isMovingLeft'.");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("isMovingLeft", false);
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("isMovingLeft", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Change direction upon collision
        if (collision.gameObject.CompareTag("EBullet") || collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else
        {
            movingRight = !movingRight;
        }
    }
}
