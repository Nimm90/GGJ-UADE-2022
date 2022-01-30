using System;
using System.Collections;
using UnityEngine;

public class AudioLerper : MonoBehaviour
{
    [SerializeField] private AudioSource normalAudio;
    [SerializeField] private AudioSource reverseAudio;
    [SerializeField] private AnimationCurve audioAnimationCurve;
    [SerializeField] private float audioLerpTime;
    private Coroutine _lerpAudioCoroutine;


    private void Awake()
    {
        normalAudio.volume = 1;
        reverseAudio.volume = 0;
    }

    public void LerpAudio(bool toReverse)
    {
        if (_lerpAudioCoroutine != null)
        {
            StopCoroutine(_lerpAudioCoroutine);
        }

        _lerpAudioCoroutine = StartCoroutine(LerpAudioCoroutine(toReverse));
    }

    private IEnumerator LerpAudioCoroutine(bool toReverse)
    {
        float counter = 0;
        var fromAudioSource = toReverse ? normalAudio : reverseAudio;
        var toAudioSource = toReverse ? reverseAudio : normalAudio;
        var fromVolume = fromAudioSource.volume;
        var toVolume = toAudioSource.volume;

        while (counter < audioLerpTime)
        {
            var lerpAmount = counter / audioLerpTime;
            var lerpCurve = audioAnimationCurve.Evaluate(lerpAmount);
            fromAudioSource.volume = Mathf.Lerp(fromVolume, 0, lerpCurve);
            toAudioSource.volume = Mathf.Lerp(toVolume, 1, lerpAmount);
            counter += Time.deltaTime;
            yield return null;
        }
    }
}