using UnityEngine;

public class Jump : PlayerActions
{
    [SerializeField] private float _jumpForce = 20f;

    [SerializeField] private LayerMask _groundLayers;

    private Rigidbody2D _rb;
    private Ray2D ray;
    private float _rayDistance = 0.51f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ray = new Ray2D(transform.position, -transform.up);
    }

    private void Update()
    {
        ray.origin = transform.position;

        Debug.DrawRay(ray.origin, ray.direction * _rayDistance, Color.cyan);

        if (!CheckGround()) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            DoJump();
    }

    private void DoJump() => _rb.AddForce(transform.up * _jumpForce);

    private bool CheckGround() => Physics2D.Raycast(ray.origin, ray.direction, _rayDistance, _groundLayers);
}
