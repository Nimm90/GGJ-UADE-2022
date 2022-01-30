using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangePPEffect : MonoBehaviour
{
    [SerializeField] private float postExposure_BlackWorld = 0.15f;
    [SerializeField] private float postExposure_WhiteWorld = 0.5f;
    [SerializeField] private float bloomAmount_BlackWorld = 6f;
    [SerializeField] private float bloomAmount_WhiteWorld = 8f;

    [SerializeField] private PostProcessVolume _volume;
    private Bloom _bloom;
    private ColorGrading _colorGrading;

    private void Awake()
    {
        _volume.profile.TryGetSettings(out _bloom);
        _volume.profile.TryGetSettings(out _colorGrading);
    }

    public void SwitchWorld(bool isJumpWorld)
    {
        if (isJumpWorld)
        {
            _bloom.intensity.value = bloomAmount_BlackWorld;
            _colorGrading.postExposure.value = postExposure_BlackWorld;

            return;
        }

        _bloom.intensity.value = bloomAmount_WhiteWorld;
        _colorGrading.postExposure.value = postExposure_WhiteWorld;
    }
}