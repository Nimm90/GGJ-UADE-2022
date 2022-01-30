using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int life = 5;

    public event Action<Damageable> OnDeath;

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
            Die();
    }

    private void Die()
    {
        OnDeath?.Invoke(this);
        Destroy(gameObject);
    }
}