
using UnityEngine;

public class TopDownMove : PlayerActions
{
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * Input.GetAxis("Vertical") * Vector3.up;
        transform.position += _speed * Time.deltaTime * Input.GetAxis("Horizontal") * Vector3.right;
    }
}
