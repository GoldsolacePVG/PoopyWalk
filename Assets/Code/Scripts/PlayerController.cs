using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer sprite;
    public Animator animator;
    public LayerMask groundMask;
    public float speed = 7f;
    private bool grounded = false;

    void Update() {
        /*float horizontal = Input.GetAxis("Horizontal");
        
        player.Translate(Vector3.right * speed * horizontal * Time.deltaTime);*/
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
        
        Debug.DrawRay(this.transform.position, Vector3.down, Color.red);
        grounded = Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, groundMask.value);
        animator.SetBool("Flying", !grounded);
    }

    public void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("Collision with ground!");
        }

        if (coll.gameObject.layer == LayerMask.NameToLayer("Bean")) {
             Destroy(coll.gameObject);
            
            Debug.Log("Collision with bean!");
            
            JetpackController jetpackController = GetComponent<JetpackController>();
            if (jetpackController != null) {
                jetpackController.ActivateJetpack();
            }
        }
    }
}