using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string _defaultSceneName = "MainMenu";

    public void OnChangeScene() => SceneManager.LoadSceneAsync(_defaultSceneName);

    public void ChangeToTargetScene(string sceneName)
    {
        Debug.Log($"Changing Scene to {sceneName}!");
        SceneManager.LoadScene(sceneName);
    }
}
