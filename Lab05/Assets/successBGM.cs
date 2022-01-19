using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class successBGM : MonoBehaviour
{
    public AudioClip successSE;
    
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
            // if (audioSource.isPlaying)
            // {
            //     audioSource.Stop();

            // }
            audioSource.PlayOneShot(successSE);
            }
    }
}
