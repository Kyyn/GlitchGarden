using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        attacker = gameObject.GetComponent<Attacker>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Defender>())
        {
            return;
        } 

        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("jumpTrigger");
        } else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }

    }
}
