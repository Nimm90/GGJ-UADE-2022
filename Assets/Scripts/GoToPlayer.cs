
using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Transform _player;
    private Vector3 _dir;

    private void Start()
    {
        _player = GameObject.Find("Player Shoot").transform;
    }

    private void Update()
    {
        _dir = _player.position - transform.position;

        transform.position += _speed * GameManager.Instance.difficultyMultiplier * Time.deltaTime * _dir.normalized;
    }
}
