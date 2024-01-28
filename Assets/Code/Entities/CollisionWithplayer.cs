using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithplayer : MonoBehaviour
{
    public GameObject bocadillo;
    // Start is called before the first frame update
    void Start()
    {
        bocadillo.SetActive(false);
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.layer == LayerMask.NameToLayer("player")) {
           bocadillo.SetActive(true);
           Debug.Log("col");
            }
        }
    }

