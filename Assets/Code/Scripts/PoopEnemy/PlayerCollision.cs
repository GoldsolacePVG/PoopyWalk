using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private string poopTag = "PoopTag";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(poopTag))
        {
            Destroy(other.gameObject);
        }
    }
}

