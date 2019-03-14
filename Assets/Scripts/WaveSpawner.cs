using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour {


    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public Text waveCountdownText;


    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;  
        }
        //Reducing the countdown each time a frame updates by the amount of time it took to update the frame
        countdown -= Time.deltaTime;
        //Limiting the countdown to a minimum of 0 seconds and a max of infinity
        //This is done to avoid the countdown getting into the negatives
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }


    IEnumerator SpawnWave()
    {
        //Spawning enemies based on the number of waves completed
        //Enemies spawn with an interval of 0.5 seconds
        waveIndex++;
        PlayerStats.Waves++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
