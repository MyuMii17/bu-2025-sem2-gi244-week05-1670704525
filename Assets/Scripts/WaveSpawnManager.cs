using UnityEngine;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave[] waves;
    public WaveController waveController;
    private int currentWave;

    void Start()
    {
        currentWave = 0;
        waveController.ChangeWave(waves[0]);
    }

    void Update()
    {
        if (waveController.IsCompleted())
        {
            currentWave++;
            waveController.ChangeWave(waves[currentWave]);
        }    
    }
}