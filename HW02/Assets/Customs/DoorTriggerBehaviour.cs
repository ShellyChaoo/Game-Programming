using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerBehaviour : MonoBehaviour {

    public GameObject door;
    private Animation m_animations;

	// Use this for initialization
	void Start () {
        if(door != null)
            m_animations = door.GetComponent<Animation>();        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Open the door           
            if (m_animations != null)
            {                
                m_animations.Play("openDoorAnimation");
            }           
            
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Close the door           
            if (m_animations != null)
            {                
                m_animations.Play("closeDoorAnimation");                
            }    
        }
    }
}
