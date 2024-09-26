using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Bullet Prefab
    [SerializeField] private float bulletSpeed; // Bullet Speed

    private Vector2 mousePosition;

    void Update()
    {
        AimAtMouse();
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            ShootProjectile();
        }
    }

    // Rotate player towards the mouse position
    void AimAtMouse()
    {
        // Get the position of the mouse in world space
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse
        Vector2 direction = mousePosition - (Vector2)transform.position;

        // Rotate the player to face the direction of the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void ShootProjectile()
    {
        // Calculate the direction and normalized vector
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        // Instantiate the projectile
        GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Start a Coroutine to set the velocity after a short delay
        StartCoroutine(SetProjectileVelocity(projectile, direction, bulletSpeed));
    }

    IEnumerator SetProjectileVelocity(GameObject projectile, Vector2 direction, float speed)
    {
        yield return new WaitForSeconds(0.01f); // Wait for a short delay
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}