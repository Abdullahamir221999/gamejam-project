using UnityEngine;

[CreateAssetMenu(fileName = "LevelSpawnSettings", menuName = "Custom/Level Spawn Settings")]
public class LevelSpawnSettings : ScriptableObject
{
    public float spawnDuration = 5f;
    public int totalEnemiesInLevel = 10; // Add this line to store the total enemies in the level.
}
