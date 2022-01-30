using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

   [SerializeField] private float timeToUpgradeDifficulty = 10;
   private float _counter;

   [HideInInspector] public float difficultyMultiplier = 1;
   [SerializeField] private float difficultyMultiplierAdder = 0.1f;
  
   private void Awake()
   {
      if (Instance == null)
         Instance = this;
      else
      {
         Destroy(gameObject);
         return;
      }
      
      DontDestroyOnLoad(gameObject);
      
   }

   private void DifficultyUp()
   {
      difficultyMultiplier += difficultyMultiplierAdder;
   }

   private void Update()
   {
      _counter += Time.deltaTime;

      if (_counter > timeToUpgradeDifficulty)
      {
         _counter = 0;
         DifficultyUp();
      }

   }
}
