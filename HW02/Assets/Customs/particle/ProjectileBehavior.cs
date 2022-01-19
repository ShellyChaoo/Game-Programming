using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    public Object ExplosionEffect;
   

	// Use this for initialization
	void Start () {
		// Destroy after 1 sec
        GameObject.Destroy(gameObject, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        // Create Explosion Effect on collided position
        if(col.contacts.Length > 0){
            if (ExplosionEffect != null && col.gameObject.tag == "enemy")
            {
                GameObject exp = GameObject.Instantiate(ExplosionEffect, Vector3.zero, Quaternion.identity) as GameObject;
               
                // exp.transform.position = col.contacts[0].point;
                exp.transform.position = col.contacts[0].point + col.contacts[0].normal * 0.5f;
                // Destroy after 5 sec
                GameObject.Destroy(exp, 5);
                // Destroy Self
                GameObject.Destroy(gameObject);                   
            }                   
        }        
    }
}
