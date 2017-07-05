using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right*speed*Time.deltaTime);

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Attacker>())
        {
            return;
        }

        if (obj.GetComponent<Attacker>())
        {
            collision.GetComponent<Health>().DealDamage(damage);
            Destroy(gameObject);
        }

    }
}
