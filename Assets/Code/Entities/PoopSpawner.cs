using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopSpawner : MonoBehaviour {
    public GameObject pooEnemyPrefab;
    public float x_offset;
    Vector3 spawner_pos;


    void OnCollisionEnter2D(Collision2D other)
    {
      if(other.gameObject.CompareTag("Player"))
      {
        spawner_pos = this.transform.position;
        Instantiate(pooEnemyPrefab, new Vector3(spawner_pos.x + x_offset, spawner_pos.y, 0f), Quaternion.identity);
        Destroy(gameObject);
      }
    }
}
