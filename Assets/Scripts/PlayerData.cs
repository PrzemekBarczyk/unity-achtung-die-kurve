using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [SerializeField] public bool IsBot = true;
    [SerializeField] public string Name;
    [SerializeField] public Material Material;
    [SerializeField] public KeyCode LeftKey;
    [SerializeField] public KeyCode RightKey;
}
