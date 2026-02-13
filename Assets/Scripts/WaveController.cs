using System.Xml.Serialization;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Transform[] spawnPoint;
    private Wave wave;
    private int spawnedEnemy = 0;
    private float nextSpawnTime = 0.0f;
    public void ChangeWave(Wave wave)
    {
        this.wave = wave;
        spawnedEnemy = 0;
        nextSpawnTime = Time.time;

    }
    public bool IsCompleted()
    {
        return spawnedEnemy >= wave.enemyCount;
    }


    void Start()
    {
        
    }
    void Update()
    {
        float waveTime = 0;
        float t = Time.time;
        if(spawnedEnemy < wave.enemyCount && t > nextSpawnTime)
        {
            Spawn();
            spawnedEnemy++;
            waveTime++;
            nextSpawnTime = t + wave.spawnInterval;
        }
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, wave.enemyPreFebs.Length);
        int pointIndex = Random.Range(0, spawnPoint.Length);

        var prefab = wave.enemyPreFebs[enemyIndex];
        var point = spawnPoint[pointIndex];

        Instantiate(prefab, point.position, Quaternion.Euler(0, 180, 0));
    }
}
