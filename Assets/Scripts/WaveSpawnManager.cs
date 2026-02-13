using UnityEngine;
using System;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave[] waves;
    public WaveController waveController;
    private int currentWave;
    public static Action OnGameEnded;
    public static WaveSpawnManager Instance;

    void Start()
    {
        currentWave = 0;
        waveController.ChangeWave(waves[0]);
    }

    void Update()
    {
        if (waveController.IsCompleted() && currentWave!=3)
        {
            currentWave++;
            waveController.ChangeWave(waves[currentWave]);
        }
    }
}