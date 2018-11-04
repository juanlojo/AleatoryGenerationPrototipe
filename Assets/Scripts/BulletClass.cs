using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour {

    public Transform enemyCharacter;
    public float bulletSpeed;

    public Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(enemyCharacter);
        //this.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 lookDirection = target.position - transform.position;
        float moveInAFrame = bulletSpeed * Time.deltaTime;

        if(lookDirection.magnitude <= moveInAFrame) //Que pasara en el momento de la colision con el enemigo.
        {
            HitTarget();
            return;
        }

        transform.Translate(lookDirection.normalized * moveInAFrame, Space.World);
	}

    void HitTarget()
    {
        Debug.Log("You suck");
    }
}
