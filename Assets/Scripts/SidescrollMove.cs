
using UnityEngine;

public class SidescrollMove : PlayerActions
{
    [SerializeField] private float _speed = 5f;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");

        if (hor < 0)
            _spriteRenderer.flipX = true;
        else if (hor > 0)
            _spriteRenderer.flipX = false;

        transform.position += _speed * Time.deltaTime * hor * Vector3.right;
    }
}
