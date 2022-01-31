using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int life = 5;

    [SerializeField] private AudioSource _takeDamageSFX;
    [SerializeField] private ParticleSystem _feedback;

    public event Action<Damageable> OnDeath;

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
            Die();
    }

    public void Die()
    {
        OnDeath?.Invoke(this);

        Instantiate(_feedback, transform.position, Quaternion.identity);

        _takeDamageSFX = Instantiate(_takeDamageSFX);
        if (_takeDamageSFX)
        {
            _takeDamageSFX.Play();
        }
            

        Destroy(gameObject);
    }
}