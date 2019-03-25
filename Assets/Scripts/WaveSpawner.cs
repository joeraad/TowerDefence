using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour {

    public static int enemiesAlive = 0;

    public Wave[] waves;
    private int waveIndex = 0;
    public float timeBetweenWaves = 2f;

    private float countdown = 2f;
    public Text waveCountdownText;

    public Transform spawnPoint;

    public GameManager gameManager;

    private void Update()
    {
        if(enemiesAlive>0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();

            this.enabled = false;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
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
        PlayerStats.Waves++;

        //Spawning enemies based on the number of waves completed
        //Enemies spawn with an interval of 0.5 seconds
        Wave wave = waves[waveIndex];

        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
        
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
    }
}
