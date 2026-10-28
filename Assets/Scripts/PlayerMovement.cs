using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    public float isGroundDumping;
    private bool isGrounded;

    public bool canInteract;

    // Cache rigid body reference
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        // Walk left and right
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            spriteRenderer.flipX = false;
        }

        // Jumping
        if (isGrounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            isGrounded = false;
        }
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(
            rb.linearVelocity.x * isGroundDumping,
            rb.linearVelocity.y);
        }
    }

    // Mark grounded if it touches an object with tag platform
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    void setInteration(bool type)
    {
        canInteract = type; 
    }
}
