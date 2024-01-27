using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform camera;
    // public Transform transform;
    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(player.position.x,camera.position.y, -10.0f);
    }
}
