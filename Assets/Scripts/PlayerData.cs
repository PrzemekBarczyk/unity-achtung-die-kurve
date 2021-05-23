using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public bool IsAlive = true;
    [SerializeField] public bool IsBot = true;
    public int Score;
    [SerializeField] public string Name;
    [SerializeField] public Material Material;
    [SerializeField] public KeyCode LeftKey;
    [SerializeField] public KeyCode RightKey;
}
