using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthSystem : MonoBehaviour
{
    [Header("Hearts Array")]
    [SerializeField] GameObject[] _hearts;

    [Header("Shooting Player")]
    [SerializeField] GameObject _player;

    private int _life;
    // Update is called once per frame
    void Update()
    {
        int _life = _player.GetComponent<PlayerDeath>()._playerHP;

        if (_life < 1)
        {
            Destroy(_hearts[0].gameObject);
        }else if (_life < 2)
        {
            Destroy(_hearts[1].gameObject);
        }else if (_life < 3)
        {
            Destroy(_hearts[2].gameObject);
        }
        
    }
}
