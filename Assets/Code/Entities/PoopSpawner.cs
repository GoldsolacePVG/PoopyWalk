using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopSpawner : MonoBehaviour {
    public GameObject poopPrefab;
    public float x_offset;
    Vector3 spawner_pos;
    private int numEnemy=0;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (numEnemy < 1) {
              spawner_pos = poopPrefab.transform.position;
              Instantiate(poopPrefab, new Vector3(spawner_pos.x + x_offset, spawner_pos.y, 0f), Quaternion.identity); 
              numEnemy++;
            }
        }
    }
}