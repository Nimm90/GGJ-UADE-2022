using UnityEngine;

public class Jump : PlayerActions
{
    // [SerializeField] private float _jumpForce = 20f;

    [SerializeField] private LayerMask _groundLayers;

    private Rigidbody2D _rb;
    private Ray2D ray;
    private float _rayDistance = 0.51f;

    [SerializeField] private KeyCode jumpKeycode1 = KeyCode.Space;
    [SerializeField] private KeyCode jumpKeyCode2 = KeyCode.W;

    [SerializeField] private PlayerPlatformerData data;

    private bool _isJumping;
    private float _jumpTimeCounter;
    [SerializeField] private float maxJumpTime;
    private bool _isGrounded;

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

        _isGrounded = CheckGround();

        if (Input.GetKeyDown(jumpKeycode1) || Input.GetKeyDown(jumpKeyCode2))
        {
            DoJump();
            return;
        }

        if (Input.GetKey(jumpKeycode1) || Input.GetKey(jumpKeyCode2))
        {
            HoldJump();
            return;
        }

        if (Input.GetKeyUp(jumpKeycode1) || Input.GetKeyUp(jumpKeyCode2))
        {
            ReleaseJump();
        }

    }


    private bool CheckGround() => Physics2D.Raycast(ray.origin, ray.direction, _rayDistance, _groundLayers);


    private void DoJump()
    {
        if (!_isGrounded) return;
        _isJumping = true;

        _jumpTimeCounter = data.JumpTime;

        _rb.velocity = Vector2.up * data.JumpForce;
    }

    public void HoldJump()
    {
        if (!_isJumping) return;

        if (_jumpTimeCounter > 0)
        {        
            _rb.velocity = Vector2.up * data.JumpForce;
            _jumpTimeCounter -= Time.deltaTime;        
        }
        else
        {
            _isJumping = false;
        }
    }

    public void ReleaseJump()
    {
        _isJumping = false;        
    }
}