using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float raycastDistance;

    void Update()
    {
        // Raycast in the direction the projectile is moving
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GetComponent<Rigidbody2D>().velocity, raycastDistance);

        // If the ray hits something, destroy the projectile and the target
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);  // Destroy the target
            Destroy(gameObject);  // Destroy the projectile
        }
    }
}
