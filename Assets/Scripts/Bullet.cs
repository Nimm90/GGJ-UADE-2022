using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _lifetime = 1f;
    [SerializeField] private int _damage = 1;

    private void Update()
    {
        _lifetime -= Time.deltaTime;

        if (_lifetime <= 0)
            Destroy(gameObject);

        transform.position += transform.up * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            collision.GetComponent<Damageable>()?.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
