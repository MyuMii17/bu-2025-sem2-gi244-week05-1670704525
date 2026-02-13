
using System;
using UnityEngine;

[Serializable]
public class Wave
{
    
    public GameObject[] enemyPreFebs;
    public int enemyCount;
    public float spawnInterval = 0f;
    public float waveInterval = 5f;
    public static Wave Instance;

}