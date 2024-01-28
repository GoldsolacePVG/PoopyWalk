using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // References to various game objects and components
    public GameObject fartVFX;
    public Transform player;
    public SpriteRenderer sprite;
    public Animator animator;
    public LayerMask groundMask;
    public Rigidbody2D rb;
    public ScreenPoopScript screen;

    // Player movement variables
    public float speed = 7f, fuel = 100.0f;  // Initialized with 100 units of fuel.

    // Grounded state and time-related variables
    private bool grounded = false;
    public bool timeslow;
    public float timetoslow = 500;

    void Update()
    {
        // Handle player movement
        HandleMovementInput();

        // Manage time-related effects
        HandleTimeSlow();

        // Clamp player's vertical position
        Vector3 position = player.position;
        position.y = Mathf.Clamp(position.y, -2.0f, 4.0f);
        player.position = position;

        // Update grounded state and handle jumping
        UpdateGroundedState();
        HandleJumpInput();
    }

    // Handle horizontal movement input
    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        player.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        // Flip sprite based on movement direction
        sprite.flipX = horizontalInput < 0f;

        // Set animator parameter for running animation
        animator.SetBool("Running", Mathf.Abs(horizontalInput) > 0f);
    }

    // Manage the time-slow effect
    void HandleTimeSlow()
    {
        if (timeslow)
        {
            timetoslow--;

            // Reset time-slow effect after a certain duration
            if (timetoslow <= 0)
            {
                timeslow = false;
                timetoslow = 500;
                speed = 7f; // Reset player speed
            }
        }
    }

    // Update the grounded state based on raycasting
    void UpdateGroundedState()
    {
        grounded = Physics2D.Raycast(player.position, Vector2.down, 2.0f, groundMask.value);

        // Set animator parameter for flying animation
        animator.SetBool("Flying", !grounded);
    }

    // Handle player jump input
    void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fuel > 0.0f && !grounded)
        {
            // Apply upward velocity for jumping
            rb.velocity = new Vector2(rb.velocity.x, 6.5f);

            // Consume fuel and create a visual effect
            fuel -= 5.0f;
            Instantiate(fartVFX, player.position, Quaternion.identity);
        }
    }

    // Handle collisions with 2D objects
    void OnCollisionEnter2D(Collision2D coll)
    {
        // Handle collision with "Perk" layer objects
        if (coll.gameObject.layer == LayerMask.NameToLayer("Perk"))
        {
            Destroy(coll.gameObject);
            // Refill fuel, but not exceeding the maximum
            fuel = Mathf.Min(fuel + 100.0f, 100.0f);
        }

        // Handle collision with "PoopEnemy" tagged objects
        if (coll.gameObject.CompareTag("PoopEnemy"))
        {
            screen.isDirty = true;
        }

        // Handle collision with "PaperPerk" tagged objects
        if (coll.gameObject.CompareTag("PaperPerk"))
        {
            screen.isPaper = true;
        }
    }

    // Handle trigger collisions with 2D objects
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Handle trigger collision with objects on the "boss" layer
        if (coll.gameObject.layer == LayerMask.NameToLayer("boss"))
        {
            // Slow down time when colliding with a boss
            speed = 1;
            timeslow = true;
        }
    }
}
