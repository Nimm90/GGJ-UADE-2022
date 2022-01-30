using System;
using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int playerMaxHP = 3;
    private int _currentPlayerHP;
    [SerializeField] private float invincibilityTime;
    private float _currentInvincibilityTime;
    public event Action<int, bool> OnChangeHealth;
    public event Action OnDeath;

    [SerializeField] private AudioSource _dieSFX;
    [SerializeField] private AudioSource _takeDamageSFX;
    [SerializeField] private ParticleSystem _dieFeedback;

    [SerializeField] private HealthSystem _otherPlayer;

    private bool _isDead = false;

    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.layer == 9)
        {     
            OnTakeDamage(1);

            Damageable d = c.gameObject.GetComponent<Damageable>();
            if (d) d.Die();
        }
    }

    private void Awake()
    {
        _currentPlayerHP = playerMaxHP;
    }

    private void Start()
    {
        OnDeath += OnDie;

        _takeDamageSFX = Instantiate(_takeDamageSFX);
        _dieSFX = Instantiate(_dieSFX);
    }

    private void Update()
    {
        if (_currentInvincibilityTime < 0)
            return;
        _currentInvincibilityTime -= Time.deltaTime;
    }

    public void OnTakeDamage(int damageToTake)
    {
        if (_currentInvincibilityTime > 0)
            return;

        _currentPlayerHP -= damageToTake;

        _takeDamageSFX.Play();

        OnChangeHealth?.Invoke(_currentPlayerHP,true);
        
        if (_currentPlayerHP <= 0)
        {
            _currentPlayerHP = 0;
            OnDeath?.Invoke();
            return;
        }
    }

    public void OnHeal(int healAmount)
    {
        _currentPlayerHP -= healAmount;
        
        if (_currentPlayerHP > playerMaxHP)
        {
            _currentInvincibilityTime = playerMaxHP;
        }
        
        OnChangeHealth?.Invoke(_currentPlayerHP,false);
    }

    public void OnDie()
    {
        if (_isDead) return;

        _isDead = true;

        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        _otherPlayer.OnDie();

        _dieFeedback.gameObject.SetActive(true);
        if(_dieSFX)
            _dieSFX.Play();

        SetPlayerActionsActive(gameObject, false);
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(_dieFeedback.main.duration + 0.002f);

        GetComponent<SceneChanger>().ChangeToTargetScene("Lose");
    }

    private void SetPlayerActionsActive(GameObject player, bool active)
    {
        PlayerActions[] playerActions = player.GetComponents<PlayerActions>();

        foreach (var pa in playerActions)
            pa.enabled = active;
    }
}
