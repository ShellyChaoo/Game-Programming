using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public float forwardSpeed = 7.0f ;
    public float backwardSpeed = 2.0f;
    public float rotateSpeed = 2.0f;
    public float jumpPower = 5.0f;
    public float useCurveHeight = 0.5f;
    public Interactable focus;	// Our current focus: Item, Enemy etc.

    private int idleState;
    private int locomotionState;
    private int jumpState;
    private int attackState;
    private Animator m_animator;
    private Rigidbody m_rb;
    private CapsuleCollider m_col;
    private float m_origColliderHeight;
    private Vector3 m_origColliderCenter;
    
	// Use this for initialization
	void Start () {
        m_animator = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody>();
        // Get state hash
        idleState = Animator.StringToHash("Base Layer.WAIT00");
        locomotionState = Animator.StringToHash("Base Layer.Locomotion");
        jumpState = Animator.StringToHash("Base Layer.JUMP00");
        attackState = Animator.StringToHash("Base Layer.Attack");

        // Adjust Collider
        m_col = gameObject.GetComponent<CapsuleCollider>();
        m_origColliderHeight = m_col.height;
        m_origColliderCenter = m_col.center;
	}

    void FixedUpdate()
    {
       // Get Input
       float v = Input.GetAxis("Vertical");
       float h = Input.GetAxis("Horizontal");
       
       if (m_animator != null)
       {
           m_animator.SetFloat("Speed", v);
           m_animator.SetFloat("Direction", h);
       }

       // Get Animator State
       AnimatorStateInfo state = m_animator.GetCurrentAnimatorStateInfo(0);
       bool lockMoving = false;
       bool jumpFlag = false;

       if (state.fullPathHash == locomotionState || state.fullPathHash == idleState)
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
                    m_rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                }
            }
            else if (Input.GetKey("x"))
            {
                m_animator.SetBool("Attack", true);
            }
        }
        else if (state.fullPathHash == jumpState)
        {
            // Disable "Jump" 
            m_animator.SetBool("Jump", false);

            jumpFlag = true;

            // Adjust collider's position
            this.adjustCollider();
        }
        else if (state.fullPathHash == attackState)
        {
            m_animator.SetBool("Attack", false);
            lockMoving = true;
        }
       
        

        Vector3 velocity = new Vector3(0.0f, 0.0f, v);

        // Transform
        if (!lockMoving)
        {
            gameObject.transform.Rotate(0, h * rotateSpeed, 0);
            float coef = 1.0f;

            if (jumpFlag)
            {
                coef = 0.6f;
            }
           
            if (v < -0.1)
            {
                gameObject.transform.Translate(velocity * backwardSpeed * Time.fixedDeltaTime);
            }
            else if (v > 0.1)
            {
                gameObject.transform.Translate(velocity * forwardSpeed * coef * Time.fixedDeltaTime);
            }
        }    
              
    }

    public void adjustCollider()
    {
        // Get current model height
        Ray ray = new Ray(gameObject.transform.position, -Vector3.up);
        RaycastHit hitInfo = new RaycastHit();
        // If the height is too large, use curve to adjust
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.distance > useCurveHeight)
            {
                float jumpHeight = m_animator.GetFloat("JumpHeight");
                // Adjust collider's height
                m_col.height = m_origColliderHeight - jumpHeight;
                // Adjust collider's center
                float  adjCenterY = m_origColliderCenter.y + jumpHeight;
                m_col.center = new Vector3(0, adjCenterY, 0);
            }
            else
            {
                m_col.height = m_origColliderHeight;
                m_col.center = m_origColliderCenter;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Interactable interactable = col.GetComponent<Interactable>();
        if (interactable != null)
        {
            SetFocus(interactable);
        }
    }
    // Set our focus to a new focus
	void SetFocus (Interactable newFocus)
	{
		// If our focus has changed
		if (newFocus != focus)
		{
			// Defocus the old one
			if (focus != null)
				focus.OnDefocused();

			focus = newFocus;	// Set our new focus
			// motor.FollowTarget(newFocus);	// Follow the new focus
		}
		
		newFocus.OnFocused(transform);
	}

    void OnTriggerExit(Collider col)
    {
        RemoveFocus();
    }

    void RemoveFocus ()
	{
		if (focus != null)
			focus.OnDefocused();

		focus = null;
		// motor.StopFollowingTarget();
	}
}
