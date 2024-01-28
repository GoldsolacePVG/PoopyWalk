using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithplayer : MonoBehaviour
{
    //public GameObject bocadillo;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
      //  bocadillo.SetActive(false);
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.layer == LayerMask.NameToLayer("player")) {
           //bocadillo.SetActive(true);
           Debug.Log("col");
           RigidbodyConstraints2D constraints = rb.constraints;


            constraints |= RigidbodyConstraints2D.FreezePositionX;


            rb.constraints = constraints;
            }
        }
    }
