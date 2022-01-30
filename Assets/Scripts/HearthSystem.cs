using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthSystem : MonoBehaviour
{

    [SerializeField] private GameObject[] hearts;

    [Header("Shooting Player")] [SerializeField]
    private HealthSystem healthSystem;

    private int _life;
    // Update is called once per frame

    private void Start()
    {
        healthSystem.OnChangeHealth += UpdateHeartDisplay;
    }

    private void UpdateHeartDisplay(int healthLeft, bool isDamage)
    {
        if (isDamage)
        {
            //Kill hearts
            for (int i = hearts.Length-1; i >= healthLeft; i--)
            {
                hearts[i].SetActive(false);
            }
            return;
        }

        //Give hearts back

        for (int i = 0; i < healthLeft; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            UpdateHeartDisplay(1,true);
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            UpdateHeartDisplay(2,false);
        }
    }
}
