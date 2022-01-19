using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */

public class TurtleController : MonoBehaviour {

	public float lookRadius = 10f;	// Detection range for player
    public Object ExplosionEffect;
	private int attackState;
	private int slimeAttackState;
	private Animator m_animator;
	private int dieState;
	private int victoryState;
	Transform target;	// Reference to the player
	NavMeshAgent agent; // Reference to the NavMeshAgent
	// CharacterCombat combat;

	// Use this for initialization
	void Start () {
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		// combat = GetComponent<CharacterCombat>();

		m_animator = gameObject.GetComponent<Animator>();
		attackState = Animator.StringToHash("Base Layer.Attack01");
		dieState = Animator.StringToHash("Base Layer.Die"); 
		slimeAttackState = Animator.StringToHash("Base Layer.RunFWD");
		victoryState = Animator.StringToHash("Base Layer.Victory");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Distance to the target
		float distance = Vector3.Distance(target.position, transform.position);
		AnimatorStateInfo state = m_animator.GetCurrentAnimatorStateInfo(0);
		// If inside the lookRadius
		if (distance <= lookRadius)
		{
			// Move towards the target
			agent.SetDestination(target.position);
			m_animator.SetBool("Attack", false);
			// If within attacking distance
			if (distance <= agent.stoppingDistance)
			{
				if (state.fullPathHash != dieState && state.fullPathHash != victoryState){
					m_animator.SetBool("Attack", true);
					FaceTarget();	// Make sure to face towards the target
					GameObject explosion = GameObject.Find("Explosion01(Clone)");
					GameObject explosion2 = GameObject.Find("FireBall_Mobile(Clone)");
					if (gameObject.name.Contains("Turtle")){
						Turtle(state,explosion);
					}
					else
					{
						Slime(state,explosion2);
					}
					// GameObject explosion = GameObject.Find("Explosion01(Clone)");
					// GameObject explosion2 = GameObject.Find("FireBall_Mobile(Clone");
					// if(!explosion){
						// m_animator.SetBool("Attack", true);
						// FaceTarget();	// Make sure to face towards the target
					// 	if(state.fullPathHash == attackState)
					// 	{
					// 		Debug.Log("attack");
					// 		GameObject exp = GameObject.Instantiate(ExplosionEffect, target.transform.position, Quaternion.identity) as GameObject;
					// 		GameObject.Destroy(exp, 1.5f);
					// 		// other.gameObject.name.Contains("");
					// 	}
					// }
				}
			}
		}
	}

	// Rotate to face the target
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	// Show the lookRadius in editor
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

	private void Slime(AnimatorStateInfo state, GameObject explosion2)
	{		
		if(explosion2 == null && state.fullPathHash == slimeAttackState)
		{
			// ExplosionCreate(1);
			// GameObject projectile = GameObject.Instantiate(ExplosionEffect, Vector3.zero, Quaternion.identity) as GameObject;
			// projectile.transform.position = gameObject.transform.position + gameObject.transform.forward * 1.5f+ gameObject.transform.up * 0.5f;
			// projectile.transform.rotation = gameObject.transform.rotation;
			// projectile.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 300);
			// GameObject.Destroy(projectile,5);
			FireCreate();
			FireCreate();
			FireCreate();

		}
	}

	private void Turtle(AnimatorStateInfo state, GameObject explosion)
	{

		if(!explosion && state.fullPathHash == attackState)
		{
			ExplosionCreate(0);
		}

	}

	private void ExplosionCreate(int coef)
	{
		GameObject exp = GameObject.Instantiate(ExplosionEffect, target.transform.position+target.transform.up*coef, Quaternion.identity) as GameObject;
		GameObject.Destroy(exp, 1.5f);
	}

	private void FireCreate()
	{
		float x = Random.Range(-5.0f, 5.0f);
		float z = Random.Range(-5.0f, 5.0f);
		Vector3 randPos = new Vector3(x,0.5f,z);

		GameObject projectile = GameObject.Instantiate(ExplosionEffect, Vector3.zero, Quaternion.identity) as GameObject;
		projectile.transform.position = gameObject.transform.position + randPos;
		// projectile.transform.position = gameObject.transform.position + gameObject.transform.forward * 1.5f+ gameObject.transform.up * 0.5f;
		projectile.transform.rotation = gameObject.transform.rotation;
		// projectile.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 300);
		GameObject.Destroy(projectile,3);
	}
}