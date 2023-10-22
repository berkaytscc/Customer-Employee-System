using UnityEngine;

[CreateAssetMenu(fileName = "CustomerSettings", menuName = "Ranchantment/Customer Settings")]
public class CustomerSettings : ScriptableObject
{
    public float MaxSpawnCooldown = 5f;
    public float SpawnCooldown = 2f;
    //public float EnterenceFreeDelay = 0.001f;

    //public int MaxCustomersInLine = 6;
    public int MaxSpawn = 9;

    public float MovementSpeed = 10f;

    public int SpawnAreaLayer;
    public int CustomerLayer;
    public int CounterLayer;
}
