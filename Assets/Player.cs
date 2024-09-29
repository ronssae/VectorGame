using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float power;
    private Vector2 mousePosition;
    private Vector2 direction;

    void Update()
    {
        direction = mousePosition - (Vector2)transform.position;

        AimAtMouse();
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    void AimAtMouse()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * power;
    }
}