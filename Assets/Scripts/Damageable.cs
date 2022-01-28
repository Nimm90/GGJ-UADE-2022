
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int _life = 5;

    public void TakeDamage(int damage)
    {
        _life -= damage;

        if (_life <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
