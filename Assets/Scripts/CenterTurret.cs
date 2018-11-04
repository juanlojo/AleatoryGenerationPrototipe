using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CenterTurret : MonoBehaviour {

    private Transform target;
    public float Range = 5f;

    public Slider healtBar;

    public AudioSource shoot;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float turretLife = 100;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        shoot = GetComponent<AudioSource>();
	}

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

            if(distanceToEnemy < 1)
            {
                turretLife -= 5;
                healtBar.value -= 5;
                if(turretLife <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        if(nearestEnemy != null && shortestDistance <= Range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            return;
        }

        if(fireCountdown <= 0f)
        {
            Fire();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
	}

    void Fire()
    {
        Debug.Log("SHOOT");
        GameObject bulletRef = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletClass bullet = bulletRef.GetComponent<BulletClass>();
        shoot.Play();

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
