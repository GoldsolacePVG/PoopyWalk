using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaScript : MonoBehaviour
{
    public float rot_speed;

    void Start() {
        rot_speed = 50.0f;
    }

    void Update() {
        float rot = rot_speed * Time.deltaTime;
        gameObject.transform.Rotate(Vector3.forward, rot);
    }
}
