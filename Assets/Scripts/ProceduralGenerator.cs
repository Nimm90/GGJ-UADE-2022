using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProceduralGenerator : MonoBehaviour
{
    [Header("Platforms")]
    [SerializeField] private GameObject _platform;
    [SerializeField] private float _minPlatformWidth, _maxPlatformWidth;
    [SerializeField] private float _platformInterval;
    private Interval _platInterval;
    [SerializeField] private Transform[] _platformSpawnPoints;
    private Vector3 _platformScale;
    private int _lastPickedPlatform;
    [SerializeField] private int enemyDeathForPlatform;
    private int _killStreak;

    [Header("Enemies")]
    [SerializeField] private Damageable[] _enemiesPrefabs;
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

            
            //var randomPlatPoint = Random.Range(0, _platformSpawnPoints.Length);
            var randomPlatPoint = _lastPickedPlatform + Random.Range(-1, 2) * 2;
            if (randomPlatPoint < 0)
            {
                randomPlatPoint = 0;
            }
            else if (randomPlatPoint >= _platformSpawnPoints.Length)
            {
                randomPlatPoint = _platformSpawnPoints.Length;
            }
            if (_lastPickedPlatform == randomPlatPoint)
            {
                randomPlatPoint += randomPlatPoint == 0 ? 1 : -1;
            }

            _lastPickedPlatform = randomPlatPoint;
            
            Debug.Log($"random plat point picked is {randomPlatPoint}");

            var go = Instantiate(_platform,
                 _platformSpawnPoints[randomPlatPoint].position,
                 Quaternion.identity);

            _platformScale.x = Random.Range(_minPlatformWidth, _maxPlatformWidth);
            go.transform.localScale = _platformScale;
        }

        if (_enInterval.Tick(Time.deltaTime))
        {
            _enInterval.Reset();

           var enemy= Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Length)],
                _enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Length)].position,
                Quaternion.identity);

          // enemy.OnDeath += SpawnRandomPlatform;
        }
    }

    private void SpawnRandomPlatform(Damageable item)
    {
        item.OnDeath -= SpawnRandomPlatform;
        _killStreak++;
        
        if (_killStreak < enemyDeathForPlatform)
            return;
        _killStreak = 0;
        
        var randomPlatPoint = Random.Range(0, _platformSpawnPoints.Length);
        if (_lastPickedPlatform == randomPlatPoint)
        {
            randomPlatPoint += randomPlatPoint == 0 ? 1 : -1;
        }

        _lastPickedPlatform = randomPlatPoint;
            
        Debug.Log($"random plat point picked is {randomPlatPoint}");

        var go = Instantiate(_platform,
            _platformSpawnPoints[randomPlatPoint].position,
            Quaternion.identity);

        _platformScale.x = Random.Range(_minPlatformWidth, _maxPlatformWidth);
        go.transform.localScale = _platformScale;
    }
}
