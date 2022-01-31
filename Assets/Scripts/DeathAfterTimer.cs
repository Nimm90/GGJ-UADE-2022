using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAfterTimer : MonoBehaviour
{
    private AudioSource _audioSrc;
    
    
    private void Awake()
    {
        _audioSrc = GetComponent<AudioSource>();
        if (_audioSrc != null)
        {
            Destroy(gameObject, _audioSrc.clip.length);        
        }
    
    }
}
