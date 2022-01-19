using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeController : MonoBehaviour
{
    public float lookRadius = 15f;	// Detection range for player
    public Object ExplosionEffect;
	private int attackState;
	private Animator m_animator;
	private int dieState;
    private int winState;
	Transform target;	// Reference to the player
	NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		// combat = GetComponent<CharacterCombat>();

		m_animator = gameObject.GetComponent<Animator>();
		attackState = Animator.StringToHash("Base Layer.RunFWD");
		dieState = Animator.StringToHash("Base Layer.Die"); 
		winState = Animator.StringToHash("Base Layer.Victory"); 
    }

    void FixedUpdate () {
		// Distance to the target
		float distance = Vector3.Distance(target.position, transform.position);
		AnimatorStateInfo state = m_animator.GetCurrentAnimatorStateInfo(0);
		// If inside the lookRadius
		if (distance <= lookRadius)
		{
			// Move towards the target
			agent.SetDestination(target.position);
			// If within attacking distance

            if (state.fullPathHash != dieState){
                // GameObject explosion = GameObject.Find("Explosion01(Clone)");
                m_animator.SetBool("Attack", true);
                FaceTarget();	// Make sure to face towards the target
                // if(!explosion && state.fullPathHash == attackState)
                // {
                // 	GameObject exp = GameObject.Instantiate(ExplosionEffect, target.transform.position, Quaternion.identity) as GameObject;
                // 	GameObject.Destroy(exp, 1.5f);
                // }
            }
		}
        m_animator.SetBool("Attack", true);
	}

    // Rotate to face the target
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
}
