using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    [Header("Platforms")]
    [SerializeField] private GameObject _platform;
    [SerializeField] private float _minPlatformWidth, _maxPlatformWidth;
    [SerializeField] private float _platformInterval;
    private Interval _platInterval;
    [SerializeField] private Transform[] _platformSpawnPoints;
    private Vector3 _platformScale;

    [Header("Enemies")]
    [SerializeField] private GameObject[] _enemiesPrefabs;
    [SerializeField] private float _enemyInterval;
    private Interval _enInterval;
    [SerializeField] private Transform[] _enemySpawnPoints;

    private void Start()
    {
        InitIntervals();

        _platformScale = _platform.transform.localScale;
    }

    private void Update()
    {
        CheckIntervals();
    }

    private void InitIntervals()
    {
        _platInterval = new Interval(_platformInterval);
        _enInterval = new Interval(_enemyInterval);
    }
    
    private void CheckIntervals()
    {
        if (_platInterval.Tick(Time.deltaTime))
        {
            _platInterval.Reset();

            GameObject go = Instantiate(_platform,
                 _platformSpawnPoints[Random.Range(0, _enemySpawnPoints.Length)].position,
                 Quaternion.identity);

            _platformScale.x = Random.Range(_minPlatformWidth, _maxPlatformWidth);
            go.transform.localScale = _platformScale;
        }

        if (_enInterval.Tick(Time.deltaTime))
        {
            _enInterval.Reset();

            Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Length)],
                _enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Length)].position,
                Quaternion.identity);
        }
    }
}
