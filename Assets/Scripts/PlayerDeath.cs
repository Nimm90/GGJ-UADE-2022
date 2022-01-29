using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public int _playerHP = 3;
    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.layer == 9)
        {     
            Debug.Log("-1 vida");
            _playerHP -= 1;
        }

        if(_playerHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
