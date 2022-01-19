using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyEvent : MonoBehaviour
{
    public GameObject canvas;
    public AudioClip loseSE;
    
	// private AudioSource audioSource;
	public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {       
            this.loseCanvas();
        }
    }

    public void loseCanvas(){
        // if (audioSource.isPlaying)
        // {
        //     audioSource.Stop();

        // }
        audioSource.PlayOneShot(loseSE);
        canvas.SetActive(true);
    }

    
}
