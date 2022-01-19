using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followController : MonoBehaviour{
    // public GameObject destination;
    public GameObject npc;
    public GameObject target;
    private UnityEngine.AI.NavMeshAgent m_naviAgent;
    private Vector3 startEnemy;
    private Vector3 startPlayer;
    public GameObject canvas;
    public AudioClip bgmSE;
    public AudioSource audioSource;
    

	// Use this for initialization
	void Start () {
       m_naviAgent = npc.GetComponent<UnityEngine.AI.NavMeshAgent>();
       startPlayer = target.GetComponent<Transform>().position;
       startEnemy = npc.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 point = target.GetComponent<Transform>().position;
        // Set destination for agent
        m_naviAgent.SetDestination(point);

      
	}

    public void restart(){
        canvas.SetActive(false);
        audioSource.Stop();
        audioSource.PlayOneShot(bgmSE);
        npc.gameObject.transform.position = startEnemy;
        target.transform.position = startPlayer;

    }
}
