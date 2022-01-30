using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score Instance;

    private TMP_Text _text;

    private bool _isPlaying;

    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (!_isPlaying) return;

        _score += Time.deltaTime;

        UpdateText();
    }

    private void UpdateText()
    {
        if (_text)
            _text.text = ((int)_score).ToString();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject scoreGO = GameObject.Find("Score Text");
        _text = scoreGO.GetComponent<TMP_Text>();

        _isPlaying = scene.name == "Game";
        if (_isPlaying) return;

        if (scene.name != "Lose") Reset();

        UpdateText();
    }

    public static float Current => _score;
    private static float _score = 0f;

    public static void Reset() => _score = 0;
}
