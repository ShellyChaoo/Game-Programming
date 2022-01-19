using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEatFood : MonoBehaviour
{
    public GameObject cat;
    public GameObject NextLevelCanvas;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = cat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {        
            if (m_animator != null)
            {                
                m_animator.SetBool("isEating",true);
                NextLevelCanvas.SetActive(true);
            }           
            
        }
    }
	void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {          
            if (m_animator != null)
            {                
                m_animator.SetBool("isEating",false);
            }    
        }
    }
}
