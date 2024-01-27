using System.Collections;
using UnityEngine;

public class JetpackController : MonoBehaviour
{
    public Animator animator;
    public float jetpackForce = 35f;
    public float jetpackDuration = 1000.0f; 
    private bool isJetpackActive = true;
    public Rigidbody2D rb;
    
    private void Update() {
        if (isJetpackActive && Input.GetKeyDown(KeyCode.Space)) {
            /*Vector3 currentPosition = transform.position;
        
            currentPosition.y += 1.50f;
            
            transform.position = currentPosition;*/
            rb.AddForce(new Vector2(0f, 3f), ForceMode2D.Impulse);
            //animator.SetBool("Running", false);
        }

        if (jetpackDuration > 0f) {
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