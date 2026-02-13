using System.Xml.Serialization;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Transform[] spawnPoint;
    private Wave wave;
    private WaveController waveController;
    private int spawnedEnemy = 0;
    public int enemyDead = 0;
    private float nextSpawnTime = 0.0f;
    private HealthV1 health;
    public void ChangeWave(Wave wave)
    {
        this.wave = wave;
        spawnedEnemy = 0;
        enemyDead = 0;
        nextSpawnTime = Time.time;

    }
    public bool IsCompleted()
    {
        return enemyDead >= wave.enemyCount || wave.waveInterval <= 0 ;
    }

    void Start()
    {
        
    }
    void Update()
    {
        float t = Time.time;
        wave.waveInterval -= Time.deltaTime;
        if(spawnedEnemy < wave.enemyCount && t > nextSpawnTime)
        {
            Spawn();
            spawnedEnemy++;
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

    void OnEnable()
    {
        HealthV1.OnEnemyDead += AddDeadCount;
        DestroyOutOfBound.OnEnemyDead += AddDeadCount;
    }
    void OnDisable()
    {
        HealthV1.OnEnemyDead -= AddDeadCount;
        DestroyOutOfBound.OnEnemyDead -= AddDeadCount;
    }
    void AddDeadCount()
    {
        enemyDead++;
        Debug.Log(enemyDead);
    }

}
