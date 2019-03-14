
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointindex = 0;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        //Giving the enemy its first waypoint to path to
        target = Waypoints.points[0];
    }
    private void Update()
    {
        //Getting the distance to the next waypoint
        Vector3 dir = target.position - transform.position;
        //Moving towards the next waypoint with a set amount of speed
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        //When the enemy object reaches the waypoint give it the next waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            Getnextwaypoint();
        }
        enemy.speed = enemy.startSpeed;

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
