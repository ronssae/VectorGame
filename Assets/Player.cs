using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float maxPower;
    [SerializeField] private float powerIncreaseRate;

    private float currentPower = 0f;
    private Vector2 mousePosition;

    void Update()
    {
        AimAtMouse();

        if (Input.GetMouseButtonDown(0))
        {
            currentPower = 0f;
        }

        if (Input.GetMouseButton(0))
        {
            currentPower += powerIncreaseRate * Time.deltaTime;
            if (currentPower > maxPower)
            {
                currentPower = maxPower;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            ShootProjectile();
        }
    }

    void AimAtMouse()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    void ShootProjectile()
    {
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
        GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        projectile.GetComponent<Rigidbody2D>().velocity = direction * currentPower;
    }
}