using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObjects/PlayerData/Shooter", order = 1, fileName = "NewShooterPlayerData")]
public class PlayerShooterData : ScriptableObject
{
   [field: SerializeField] public float MovementSpeed { get; private set; }
}
