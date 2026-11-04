using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    public float isGroundDumping;
    public float isAirDumping;
    private bool isGrounded;

    public bool canInteract;

    //variables for the WaveDash
    private Vector2 moveInput;
    private bool canDash = false;
    private bool isDashing = false;
    private bool isAiming = false;
    private float dashingPower = 70f;
    private float dashingTime = 0.2f;

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
        
        if (isDashing)
        {
            return;
        }

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        // Walk left and right
        if (Input.GetKey(KeyCode.A) && !isAiming)
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) && !isAiming)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            spriteRenderer.flipX = false;
        }

        // Jumping
        if (isGrounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            isAiming = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            isGrounded = false;
        }
        if (isGrounded)
        {
            canDash = true;
            isAiming = false;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
            rb.linearVelocity = new Vector2(
            rb.linearVelocity.x * isGroundDumping,
            rb.linearVelocity.y);
        } else if (Input.GetMouseButton(0))
        {
            isAiming = true;
            spriteRenderer.flipX = false;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 direction = (mousePos - transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            
            
        } else if (Input.GetMouseButtonUp(0) && canDash)
        {

            StartCoroutine(Dash(rb));
        }
        else
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x * isAirDumping,
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

    private IEnumerator Dash(Rigidbody2D direction)
    {
        canDash = false;
        isDashing = true;
        int xr = 0;
        int yr = 0;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        if(direction.rotation == 0)
        {
            xr = 1;
            yr = 0;
        }
        else if(0 < direction.rotation && direction.rotation < 90 )
        {
            xr = 1;
            yr = 1;
        }
        else if(direction.rotation == 90)
        {
            xr = 0;
            yr = 1;
        } else if(90 < direction.rotation && direction.rotation < 180)
        {
            xr = -1;
            yr = 1;
        } else if(direction.rotation == 180)
        {
            xr = -1;
            yr = 0;
        } else if (-180 < direction.rotation && direction.rotation < -90)
        {
            xr = -1;
            yr = -1;
        }
        else if (direction.rotation == -90)
        {
            xr = 0;
            yr = -1;
        }
        else if (-90 < direction.rotation && direction.rotation < 0)
        {
            xr = 1;
            yr = -1;
        }

        rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower * xr, transform.localScale.y * dashingPower * yr);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
    }
}
