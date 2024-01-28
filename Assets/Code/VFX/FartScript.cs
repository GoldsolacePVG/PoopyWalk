using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartScript : MonoBehaviour
{
    private float timeAlive = 100.0f;

    void Update() {
        timeAlive--;
        if (timeAlive <= 0.0f) {
            Destroy(gameObject);
        }
    }
}
