using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject fartVFX;
    public Transform player;
    public SpriteRenderer sprite;
    public Animator animator;
    public LayerMask groundMask;
    public Rigidbody2D rb;
    public ScreenPoopScript screen;
    public float speed = 7f, fuel = 0.0f;
    private bool grounded = false;

    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
            sprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.D)) {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
            sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            animator.SetBool("Running", true);
        }else{
            animator.SetBool("Running", false);
        }
        
        Vector3 position = player.transform.position;
        position.y = Mathf.Clamp(position.y, -2.0f, 4.0f);
        transform.position = position;
        
        grounded = Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, groundMask.value);
        animator.SetBool("Flying", !grounded);
        
        if (Input.GetKeyDown(KeyCode.Space) && fuel > 0.0f) {
            rb.velocity = new Vector2(rb.velocity.x, 6.5f);
            fuel -= 5.0f;
            Instantiate(fartVFX, this.transform.position, Quaternion.identity);
        }
    }

    public void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Perk")) {
            Destroy(coll.gameObject);
            if (fuel < 100.0f) {
                fuel += 100.0f - fuel;
            }
        }

        if (coll.gameObject.CompareTag("PoopEnemy")) {
            screen.isDirty = true;
        }

        if (coll.gameObject.CompareTag("PaperPerk")) {
            screen.isPaper = true;
        }
    }
}