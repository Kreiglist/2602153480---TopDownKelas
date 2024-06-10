using UnityEngine;

internal interface IDamageable
{
    void TakeDamage(int damage);
    void OnTriggerEnter2D(Collider2D collision);
}