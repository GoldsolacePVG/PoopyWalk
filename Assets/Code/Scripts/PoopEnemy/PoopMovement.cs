using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector3 movement = new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
