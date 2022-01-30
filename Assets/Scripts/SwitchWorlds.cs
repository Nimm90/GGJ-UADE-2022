using System;
using UnityEngine;
using UnityEngine.Events;

public class SwitchWorlds : MonoBehaviour
{
    [SerializeField] private Camera _jumpWorldCamera, _shootWorldCamera;

    private Camera _mainCamera;

    [SerializeField] private bool _isInJumpWorld = false;
    [SerializeField] private GameObject _playerShoot, _playerJump;

    public UnityEvent<bool> OnSwitchWorld;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(_isInJumpWorld)
            {
                _mainCamera.transform.position = _shootWorldCamera.transform.position;
                _shootWorldCamera.gameObject.SetActive(false);
                _jumpWorldCamera.gameObject.SetActive(true);
                SetPlayerActionsActive(_playerJump, false);
                SetPlayerActionsActive(_playerShoot, true);
            }
            else
            {
                _mainCamera.transform.position = _jumpWorldCamera.transform.position;
                _jumpWorldCamera.gameObject.SetActive(false);
                _shootWorldCamera.gameObject.SetActive(true);
                SetPlayerActionsActive(_playerJump, true);
                SetPlayerActionsActive(_playerShoot, false);
            }
            _isInJumpWorld = !_isInJumpWorld;
            
            OnSwitchWorld?.Invoke(_isInJumpWorld);
        }
    }

    private void SetPlayerActionsActive(GameObject player, bool active)
    {
        PlayerActions[] playerActions = player.GetComponents<PlayerActions>();

        foreach (var pa in playerActions)
            pa.enabled = active;
    }
}
