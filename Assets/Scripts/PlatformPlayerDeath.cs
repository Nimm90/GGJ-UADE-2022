using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerDeath : MonoBehaviour
{

    [SerializeField] GameObject _platformerPlayer;

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(_platformerPlayer);
    }

}