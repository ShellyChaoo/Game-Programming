using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float jumpForce;
	private int carrotCount;
	private Vector3 initPos;
    private Quaternion lookDir;
	private bool canJump;
	public Text content;
	private string count;
	public AudioClip buttonSE;

	// private AudioSource audioSource;
	public AudioSource audioSource;
	public Image healthbar;
	private float health;
	Rigidbody rb;

	void Start()
    {
        rb = GetComponent<Rigidbody>();
		initPos = this.gameObject.transform.position;
		canJump = true;
		carrotCount = 0;
		GetMusicInfo(carrotCount);
		health = 1.0f;
		healthbar.fillAmount = health;
	}

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.R))
		{
			this.gameObject.transform.position = initPos;
		}

		if(canJump && Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
			canJump = false;
		}
    }

	void FixedUpdate()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		Vector2 v = new Vector2(inputX, inputY);

        if (v.magnitude > 1.0f)
            v = v.normalized;

		if (v.magnitude > 0.1f)
			lookDir = Quaternion.LookRotation(new Vector3(v.x, 0.0f, v.y));

		this.gameObject.transform.rotation = 
			Quaternion.Slerp(this.gameObject.transform.rotation, lookDir, rotateSpeed);
        
		rb.velocity = new Vector3(v.x * speed, rb.velocity.y, v.y * speed);
        rb.angularVelocity = Vector3.zero;
	}

	private void OnCollisionEnter(Collision collision)
	{
		canJump = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Carrot")){
			Destroy(other.gameObject);
			carrotCount += 1;
			GetMusicInfo(carrotCount);
			audioSource.PlayOneShot(buttonSE);
		}

		
		if (other.CompareTag("Out")){
			this.gameObject.transform.position = initPos;
			health -=0.2f;
			ChangeHealth(health);
		}	
	}


	public void GetMusicInfo(int countInt)
    {

		count = countInt.ToString();
        content.text = count;
    }

	public void ChangeHealth(float value)
	{
		healthbar.fillAmount = value;
	}
}
