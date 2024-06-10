using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Ship : MonoBehaviour, IMovement, IShoot, IDamageable
{
    private Rigidbody2D rb2d;
    private Weapon weapon;

    [SerializeField] private Health health;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
    }

    public void SetDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
        rb2d.velocity = direction * speed;
    }

    public void Shoot()
    {
        weapon.Shoot();
    }

    public void TakeDamage(int damage)
    {
        health.Reduce(damage);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(1);
    }

    public Vector2 GetDirection()
    {
        Debug.Log(rb2d.velocity.normalized);
        return rb2d.velocity.normalized;
    }
}
