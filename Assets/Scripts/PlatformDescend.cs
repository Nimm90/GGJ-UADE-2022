using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDescend : MonoBehaviour
{
    [SerializeField] private float _velCaida;

    // Update is called once per frame
    void Update()
    {
        transform.position += _velCaida * GameManager.Instance.difficultyMultiplier * Time.deltaTime * Vector3.down;
        //transform.Translate(0, -_velCaida * Time.deltaTime, 0);
    }
}
