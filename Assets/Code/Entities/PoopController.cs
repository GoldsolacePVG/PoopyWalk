using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopController : MonoBehaviour {
    public float speed = 5f;
    void Update() {
        Vector3 movement = new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}