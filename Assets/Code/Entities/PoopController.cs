using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopController : MonoBehaviour {
    public float speed = 5.0f;
    void Update() {
        Vector3 movement = new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("HumanEnemy")) {
            Destroy(gameObject);
        }

    }
}
