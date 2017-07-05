using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile,  gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;


    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");

        if (projectileParent == null)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();


    }

    // Update is called once per frame
    void Update () {
		if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        } else
        {
            animator.SetBool("isAttacking", false);
        }
	}

    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in lane");
    }

    bool IsAttackerAheadInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        } 

        foreach (Transform child in myLaneSpawner.transform)
        {
            if (child.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        return false;
    }

    private void Fire ()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
        
    }
}
