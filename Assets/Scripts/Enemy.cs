
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    private Transform target;
    private int waypointindex = 0;
    public int health = 100;
    public int value = 20;
    public GameObject deathEffect;


    private void Start()
    {
        //Giving the enemy its first waypoint to path to
        target = Waypoints.points[0];
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health<=0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    private void Update()
    {
        //Getting the distance to the next waypoint
        Vector3 dir=target.position-transform.position;
        //Moving towards the next waypoint with a set amount of speed
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);

        //When the enemy object reaches the waypoint give it the next waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            Getnextwaypoint();
        }

    }

    void Getnextwaypoint()
        //supply the caller with the next waypoint
        //if there is none call EndPath
    {
        if (waypointindex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        waypointindex++;
        target = Waypoints.points[waypointindex];
    }

    void EndPath()
    {
        //Remove a life from the player and destroy the caller
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
