
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public GameObject impactEffect;
    public GameObject smallImpactEffect;
    public float explossionRadius = 0f;
    public float speed=70f;
    public int damage = 50;

    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Update is called once per frame
	void Update () {
        if (target == null && gameObject.tag == "Missile")
                target = MissileLockon();
            if(target==null)
            {
                GameObject effectIns = (GameObject)Instantiate(smallImpactEffect, transform.position, transform.rotation);
                Destroy(effectIns, 5f);
                Destroy(gameObject);
                return;
            }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);
	}

    void HitTarget()
    {
        GameObject effectIns= (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        if(explossionRadius>0f)
        {
            Explode();
        }else
        {
            Damage(target);
        }
        //Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void Explode()
    {
        Collider[] colliders =Physics.OverlapSphere(transform.position,explossionRadius);//makes a sphere and returns all the objects that collides with the sphere
        foreach (Collider collider in colliders)
        {
            if(collider.tag=="Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explossionRadius);
    }


    private string enemyTag = "Enemy";
    private float range = 20f;
    private Transform missileTarget;
    Transform MissileLockon()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
            return nearestEnemy.transform; 
        else
            return null;

    }




}
