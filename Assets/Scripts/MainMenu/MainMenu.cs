using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject mainScreen;

    [SerializeField] private string sceneToLoad;

    public event Action OnToggle;
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
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        return;
        #endif
        
        Application.Quit();
        
    }

}
