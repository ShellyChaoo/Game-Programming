using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character2DControl : MonoBehaviour 
{
	private Character2D character;
	private bool jump;
	private float movingSpeed;
    private int score = 0;
    public Text textScore;

	// Use this for initialization
	void Start () 
	{
		character = GetComponent<Character2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//get jump input by "jump" button set in input setting
		if (Input.GetButtonDown("Jump")) jump = true;
        textScore.text = score.ToString();
	}

	void FixedUpdate()
	{
		//get input by Axis set in input setting
		movingSpeed = Input.GetAxis("Horizontal");

		//pass parameters to character script, and then it can move
		character.Move(movingSpeed, jump);

		//jump is reset after each time that physical engine updated
		jump = false;

        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score=0;
        }
	}

    void OnCollisionEnter2D(Collision2D hit)
	{
        if(hit.gameObject.tag == "Enemy"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score =0;

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Score"){
            score +=1;
            

        }
    }
}
