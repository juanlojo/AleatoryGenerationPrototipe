using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlyAttack : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform target;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public float Range;

	// Use this for initialization
	void Start () {
        InvokeRepeating("updateTargetForPlayer", 0f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            return;
        }

        if (fireCountdown <= 0f)
        {
            RangedAttack();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void updateTargetForPlayer()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
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

        if (nearestEnemy != null && shortestDistance <= Range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void RangedAttack()
    {
        GameObject bulletRef = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletClass bullet = bulletRef.GetComponent<BulletClass>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
