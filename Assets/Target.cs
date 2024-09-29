using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] LineRenderer lineOfSight;
    [SerializeField] private Gradient redColor, greenColor;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        lineOfSight.SetPosition(0, transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 50f);

        if (hit.collider.CompareTag("Boundary"))
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
            lineOfSight.SetPosition(1, hit.point);
            lineOfSight.colorGradient = greenColor;
        }
        else if (hit.collider.CompareTag("Player"))
        {
            Destroy(hit.collider.gameObject);
        }
        else
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            lineOfSight.SetPosition(1, hit.point);
            lineOfSight.colorGradient = redColor;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
