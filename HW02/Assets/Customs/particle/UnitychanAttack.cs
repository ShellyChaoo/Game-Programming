using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanAttack : MonoBehaviour
{
    public Object Projectile;
    // Start is called before the first frame update
    public GameObject GunObject;
    private Animator anim;
						
    static int shootState = Animator.StringToHash("Base Layer.Shooting");
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKey(KeyCode.Q))
        {
            GameObject bullet = GameObject.Find("bullet(Clone)");

            // Shoot
            // anim.SetBool("Attack", true);
            if (!bullet)
            {
                GameObject projectile = GameObject.Instantiate(Projectile, Vector3.zero, Quaternion.identity) as GameObject;
                projectile.transform.position = gameObject.transform.position + gameObject.transform.forward * 0.5f + gameObject.transform.up * 1.5f;
                projectile.transform.rotation = gameObject.transform.rotation;
                projectile.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 300);

                // projectile.transform.position = GunObject.transform.position + GunObject.transform.forward * 0.5f;
                // projectile.transform.rotation = gameObject.transform.rotation;
                // projectile.GetComponent<Rigidbody>().AddForce(GunObject.transform.forward * 300);
            }
        }
        // else if (state.fullPathHash == shootState)
        // {
        //     Debug.Log("attack=false");
        //     anim.SetBool("Attack", false);
        // }
        
    }
}
