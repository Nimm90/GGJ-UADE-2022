using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject mainScreen;

    [SerializeField] private string sceneToLoad;

    public UnityEvent OnAnyButtonPress;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        creditsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void Toggler()
    {
        creditsScreen.SetActive(!creditsScreen.activeSelf);
        mainScreen.SetActive(!mainScreen.activeSelf);
        OnAnyButtonPress?.Invoke();
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene(sceneToLoad);
        OnAnyButtonPress?.Invoke();
    }

    public void QuitGame()
    {
        OnAnyButtonPress?.Invoke();
#if UNITY_EDITOR

        EditorApplication.isPlaying = false;
        return;
#endif

        Application.Quit();
    }
}