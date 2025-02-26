using UnityEngine;

public class Astromove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public static int lives;
    public GameObject gunPrefab; // The gun prefab to spawn
    public Transform handTransform; // The transform of the player's hand
    public GameObject bulletPrefab; // The bullet prefab to spawn
    private GameObject spawnedGun;
    public AudioClip gunFireSound; // The sound file to play when the gun is fired
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        // Ensure the Rigidbody2D has gravity enabled
        rb.gravityScale = 1;
        lives = 3;

        // Ensure the AudioSource component is correctly configured and the sound file is assigned
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        if (gunFireSound != null)
        {
            audioSource.clip = gunFireSound;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        if (move > 0)
        {
            spriteRenderer.flipX = true; // Face right
            animator.SetBool("isFacingRight", false);
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = false; // Face left
            animator.SetBool("isFacingRight", true);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1")) // Assuming "Fire1" is the attack button
        {
            if (spawnedGun == null)
            {
                spawnedGun = Instantiate(gunPrefab, handTransform);
                spawnedGun.transform.localPosition = new Vector3(spriteRenderer.flipX ? -0.05f : 0.05f, 0, 0); // Adjust local position based on direction
                spawnedGun.transform.localRotation = Quaternion.identity; // Reset local rotation

                // Set the sorting order to ensure the gun appears in front
                SpriteRenderer gunSpriteRenderer = spawnedGun.GetComponent<SpriteRenderer>();
                if (gunSpriteRenderer != null)
                {
                    gunSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder + 1;
                    gunSpriteRenderer.flipX = spriteRenderer.flipX; // Flip the gun sprite based on player direction
                }
            }

            // Play the gun fire sound
            if (audioSource != null && gunFireSound != null)
            {
                audioSource.PlayOneShot(gunFireSound);
            }

            // Spawn a bullet from the tip of the gun
            Vector2 bulletDirection = spriteRenderer.flipX ? Vector2.right : Vector2.left;
            GameObject bullet = Instantiate(bulletPrefab, spawnedGun.transform.position, Quaternion.identity);
            if (bullet != null)
            {
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    bulletScript.Initialize(bulletDirection);

                    // Set the sorting order to ensure the bullet appears in front
                    SpriteRenderer bulletSpriteRenderer = bullet.GetComponent<SpriteRenderer>();
                    if (bulletSpriteRenderer != null)
                    {
                        bulletSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder + 2;
                    }
                }
                else
                {
                    Debug.LogError("Bullet script not found on bullet prefab.");
                }
            }
            else
            {
                Debug.LogError("Bullet prefab instantiation failed.");
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (spawnedGun != null)
            {
                Destroy(spawnedGun);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Kill()
    {
        lives = lives - 1;
        if (lives == 0)
        {
            gameObject.SendMessage("Die");
        }
    }
}
