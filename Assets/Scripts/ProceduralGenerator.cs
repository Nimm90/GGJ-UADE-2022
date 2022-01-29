using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    [Header("Platforms")]
    [SerializeField] private GameObject _platform;
    [SerializeField] private float _minPlatformWidth, _maxPlatformWidth;
    [SerializeField] private float _platformInterval;
    private Interval _platInterval;

    [Header("Enemies")]
    [SerializeField] private GameObject[] _enemiesPrefabs;
    [SerializeField] private float _enemyInterval;
    private Interval _enInterval;
    [SerializeField] private Transform[] _enemySpawnPoints;

    private void Start()
    {
        InitIntervals();
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
            
           Instantiate(_platform, new Vector3(Random.Range(40, 59), 7, 0) ,
                Quaternion.identity );
            
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
