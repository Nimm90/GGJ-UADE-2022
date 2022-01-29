using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class InvertEffect : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    private InvertedPPSSettings _invertFXSettings;

    private void Start()
    {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out _invertFXSettings);
    }

    private void Update()
    {
        if (_invertFXSettings._UDisplacement.value >= 1
            || _invertFXSettings._UDisplacement.value <= 0)
            _speed *= -1;

        _invertFXSettings._UDisplacement.value += _speed * Time.deltaTime;
    }
}
