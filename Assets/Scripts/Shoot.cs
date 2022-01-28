using UnityEngine;

public class Shoot : PlayerActions
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _fireRate = 0.05f;
    private float _fr;

    [SerializeField] private GameObject _bulletPrefab;

    private void Start()
    {
        _fr = _fireRate;
    }

    private void Update()
    {
        _fr -= Time.deltaTime;

        if (_fr > 0) return;

        _fr = _fireRate;

        if(Input.GetMouseButton(0))
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }
}
