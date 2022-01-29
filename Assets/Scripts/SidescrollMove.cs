
using UnityEngine;

public class SidescrollMove : PlayerActions
{
    [SerializeField] private float _speed = 5f;

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerPlatformerData data;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var hor = Input.GetAxis("Horizontal");

        if (hor < 0)
            _spriteRenderer.flipX = true;
        else if (hor > 0)
            _spriteRenderer.flipX = false;

        transform.position += data.MovementSpeed * Time.deltaTime * hor * Vector3.right;
    }
}
