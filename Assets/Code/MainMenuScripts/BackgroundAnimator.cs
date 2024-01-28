using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimator : MonoBehaviour
{
    public Renderer background;
    public float scrollSpeed = 0.5f;
    public Vector2 currentOffset;

    private void Update()
    {
        currentOffset += Vector2.one * scrollSpeed * Time.deltaTime;
        background.material.SetTextureOffset("_MainTex", currentOffset);
    }
}
