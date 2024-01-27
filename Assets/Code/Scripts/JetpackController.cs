using System.Collections;
using UnityEngine;

public class JetpackController : MonoBehaviour
{
    public float jetpackForce = 35f;
    public float jetpackDuration = 10f; 
    private bool isJetpackActive = false;

    public Rigidbody2D rb;
    
    private void Update()
{
    if (isJetpackActive && Input.GetKey(KeyCode.Space))
    {
        Vector3 currentPosition = transform.position;

    
         currentPosition.y += 0.10f;

    
         transform.position = currentPosition;
    }

    if (jetpackDuration > 0f)
    {
        jetpackDuration -= Time.deltaTime;
    }
    else
    {
        isJetpackActive = false;
        jetpackDuration = 0f;
    }
}



   

    public void ActivateJetpack()
    {
        
        isJetpackActive = true;
        jetpackDuration = 10f;
    }
}