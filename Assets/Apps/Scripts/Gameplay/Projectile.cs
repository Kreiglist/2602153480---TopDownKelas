using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    private float duration;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        duration = 0;
    }

    private void Start()
    {
        rb2d.velocity = transform.up * speed;
    }

    private void Update()
    {
        duration += Time.deltaTime;

        if (duration >= lifetime)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
