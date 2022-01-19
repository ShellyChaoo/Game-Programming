using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    public GameObject canvas;
    private Animator m_animator;
    private int closeState;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        closeState = Animator.StringToHash("Base Layer.Closed");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        AnimatorStateInfo state = m_animator.GetCurrentAnimatorStateInfo(0);
        if (col.gameObject.tag == "Player")
        {
            if (state.fullPathHash == closeState)
            {
                m_animator.SetBool("foundTreasure", true);
                canvas.SetActive(true);
            }
        }
    }
}
