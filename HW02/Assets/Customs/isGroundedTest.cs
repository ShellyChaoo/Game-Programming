using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGroundedTest : MonoBehaviour
{
    private bool m_isGround;
    // public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isGround(){ return m_isGround; }

    private void OnCollisionEnter(Collision other)
    {
        // if(other.gameObject.name == floor.name)
        // {
        //     m_isGround = true;
        // }
        if (other.gameObject.tag == "floor")
        {
            m_isGround = true;          
            
        }
            
    }

    private void OnCollisionExit(Collision other)
    {
        // if(other.gameObject.name == floor.name) m_isGround = false;
        if (other.gameObject.tag == "floor") m_isGround = false;
    }
}
