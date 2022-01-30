using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*[SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject aboutScreen;*/

    [SerializeField] private string sceneToLoad;

    [SerializeField] private GameObject[] screens;
    [SerializeField] private GameObject initialScreen;

    public UnityEvent OnAnyButtonPress;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SetAllScreenInactive();

        initialScreen.SetActive(true);

        /*creditsScreen.SetActive(false);
        mainScreen.SetActive(true);
        aboutScreen.SetActive(false);*/
    }

    /*public void Toggler()
    {
        creditsScreen.SetActive(!creditsScreen.activeSelf);
        mainScreen.SetActive(!mainScreen.activeSelf);
        OnAnyButtonPress?.Invoke();
    }*/

    /*public void SetCreditsScreenActive()
    {
        creditsScreen.SetActive(true);
        mainScreen.SetActive(false);
        aboutScreen.SetActive(false);

        OnAnyButtonPress?.Invoke();
    }

    public void SetAboutScreenActive()
    {
        creditsScreen.SetActive(false);
        mainScreen.SetActive(false);
        aboutScreen.SetActive(true);

        OnAnyButtonPress?.Invoke();
    }

    public void SetMainScreenActive()
    {
        creditsScreen.SetActive(false);
        mainScreen.SetActive(true);
        aboutScreen.SetActive(false);

        OnAnyButtonPress?.Invoke();
    }*/

    public void SetScreenActive(GameObject screen)
    {
        SetAllScreenInactive();
        screen.SetActive(true);

        OnAnyButtonPress?.Invoke();
    }

    private void SetAllScreenInactive()
    {
        foreach (var s in screens)
            s.SetActive(false);
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