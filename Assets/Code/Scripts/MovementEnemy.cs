using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocity;
    public LayerMask front;
    public float distanceInFront;
    public Transform frontController;
    public bool informationInFront;
    public bool facingRight = true;
    public bool talking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        informationInFront = Physics2D.Raycast(frontController.position, transform.right, distanceInFront, front);

        if (informationInFront)
        {
            Flip();
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocity *= -1;
    }
}
