using System;
using UnityEngine;
using UnityEngine.UI;

public class BaseScreen : MonoBehaviour
{
    public Action OnAnyButtonPressed => () => {};

    [SerializeField] private AudioSource _buttonSFX;
    [SerializeField] private Button[] _buttons;

    private void Start()
    {
        foreach (var b in _buttons)
            b.onClick.AddListener(PlaySFX);
    }

    private void PlaySFX() => _buttonSFX.Play();
}
