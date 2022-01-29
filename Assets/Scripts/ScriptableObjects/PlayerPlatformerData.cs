using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerData/Platformer", order = 1, fileName = "NewPlatformerPlayerData")]
public class PlayerPlatformerData : ScriptableObject
{
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; } = 30;
    [field: SerializeField] public float JumpTime { get; private set; } = 30;
   
}