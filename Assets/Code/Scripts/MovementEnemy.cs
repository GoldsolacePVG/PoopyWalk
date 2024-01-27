using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocity;
    public LayerMask front;
    public float distanciaenfrente;
    public Transform controladorenfrente;
    public bool informacionenfrente;
    public bool mirandoderecha=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(velocity,rb.velocity.y);
        informacionenfrente=Physics2D.Raycast(controladorenfrente.position,transform.right,distanciaenfrente,front);
    
         if(informacionenfrente){

             Girar();
         }    
    }

    public void Girar(){


        mirandoderecha=!mirandoderecha;
        transform.eulerAngles= new Vector3(0,transform.eulerAngles.y+180,0);
        velocity*=-1;
    }
}
