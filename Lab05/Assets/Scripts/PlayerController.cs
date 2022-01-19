using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int idleState;
    private int runState;
    private int jumpState;
    private Rigidbody rb;
    private Animator m_animator;
    public float speed;
    public float rotateSpeed = 2.0f;
    public float jumpPower = 5.0f;

    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        idleState = Animator.StringToHash("Base Layer.Idle");
        runState = Animator.StringToHash("Base Layer.Running");
        jumpState = Animator.StringToHash("Base Layer.Jumping");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
         if (m_animator != null)
       {
           m_animator.SetFloat("Speed", v);
        //    m_animator.SetFloat("Direction", h);
       }

       AnimatorStateInfo state = m_animator.GetCurrentAnimatorStateInfo(0);
       bool jumpFlag = false;

       if (state.fullPathHash == runState || state.fullPathHash == idleState)
        {
            // When character is moving, she can jump now
            if (Input.GetKey(KeyCode.Space))
            {
                bool isgrounded = gameObject.GetComponent<isGroundedTest>().isGround();

                // The controller is not transition 
                if (!m_animator.IsInTransition(0) && isgrounded)
                {
                    // Enable "Jump" 
                    m_animator.SetBool("Jump", true);
                    // Add jump force to rigidbody
                    rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                }
            }
        }
        else if (state.fullPathHash == jumpState)
        {
            // Disable "Jump" 
            m_animator.SetBool("Jump", false);

            jumpFlag = true;
        }

       Vector3 velocity = new Vector3(0.0f, 0.0f, v);

       gameObject.transform.Rotate(0, h * rotateSpeed, 0);
        float coef = 1.0f;

        if (jumpFlag)
        {
            coef = 0.6f;
        }
        
        if (v > 0.1)
        {
            gameObject.transform.Translate(velocity * speed * coef * Time.fixedDeltaTime);
        }

        // rb.velocity = new Vector3(x,0,z).normalized * speed + Vector3.up * rb.velocity.y;

        // if(Mathf.Abs(x) > 0.1 || Mathf.Abs(z) > 0.1)
        // {
        //     this.transform.eulerAngles = new Vector3(0, Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.x , rb.velocity.z),0);
        // }
    }
}
