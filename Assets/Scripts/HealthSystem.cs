using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int playerMaxHP = 3;
    private int _currentPlayerHP;
    [SerializeField] private float invincibilityTime;
    private float _currentInvincibilityTime;
    public event Action<int, bool> OnChangeHealth;
    public event Action OnDeath;
    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.layer == 9)
        {     
            OnTakeDamage(1);
        }
    }

    private void Awake()
    {
        _currentPlayerHP = playerMaxHP;
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
        
        if (_currentPlayerHP <= 0)
        {
            _currentPlayerHP = 0;
            OnDeath?.Invoke();
            return;
        }
        
        OnChangeHealth?.Invoke(_currentPlayerHP,true);
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
    
}
