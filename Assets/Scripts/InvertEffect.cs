using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class InvertEffect : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    private InvertedPPSSettings _invertFXSettings;
    [SerializeField] private AnimationCurve curve;
    private float _lerper;
    [SerializeField] private float returnWaitTime;
    private WaitForSeconds _waitCommand;

    private void Start()
    {
        var volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out _invertFXSettings);
        _waitCommand = new WaitForSeconds(returnWaitTime);

        StartCoroutine(LerpDisplacement());
    }
    private IEnumerator LerpDisplacement()
    {
        while (true)
        {
            _lerper += _speed * Time.deltaTime;
            if (_lerper > 1 || _lerper < 0)
            {
                yield return _waitCommand;
                _speed *= -1;
            }

            _invertFXSettings._UDisplacement.value = curve.Evaluate(_lerper);
            yield return null;
        }
    }
}