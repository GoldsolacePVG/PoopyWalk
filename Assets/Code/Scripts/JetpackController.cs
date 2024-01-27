using System.Collections;
using UnityEngine;

public class JetpackController : MonoBehaviour
{
    public Animator animator;
    public float jetpackForce = 35.0f;
    public float jetpackDuration = 1000.0f; 
    private bool isJetpackActive = true;
    public Rigidbody2D rb;
    
    private void Update() {
        if (isJetpackActive && Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector2(rb.velocity.x, 6.5f);
        }

        if (jetpackDuration > 0.0f) {
            jetpackDuration -= Time.deltaTime;
        }else{
            isJetpackActive = false;
            jetpackDuration = 0f;
        }
    }
    
    public void ActivateJetpack() {
        isJetpackActive = true;
        jetpackDuration = 10f;
    }
}