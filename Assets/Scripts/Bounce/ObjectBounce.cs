using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    private Vector3 dir;
    private Rigidbody2D rb;
    [SerializeField] private int bouncePower;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 bounceAngle = Vector3.Reflect(dir, other.GetContact(0).normal);
                rb.velocity = bounceAngle.normalized * dir.magnitude * bouncePower;
            }
        }
    }

    private void LateUpdate()
    {
        if (rb != null)
        {
            dir = rb.velocity;
        }
    }
}
