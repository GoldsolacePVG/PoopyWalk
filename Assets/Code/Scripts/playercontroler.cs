using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public float speed = 7f;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        

        player.Translate(Vector3.right * speed * horizontal * Time.deltaTime);



        Vector3 position = player.transform.position;
        position.y = Mathf.Clamp(position.y, -2.0f, 4.0f);
        transform.position = position;
    }

    

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("suelo"))
        {
            Debug.Log("Collision with ground!");
        }

        if (coll.gameObject.layer == LayerMask.NameToLayer("judia"))
        {
             Destroy(coll.gameObject);
            
            Debug.Log("Collision with judia!");
            
            JetpackController jetpackController = GetComponent<JetpackController>();
            if (jetpackController != null)
            {
                jetpackController.ActivateJetpack();
            }
           
            
        }
    
    }
}