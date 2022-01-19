using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed=5.0f;
    private bool faceLeft = true;
    public Transform rightPoint, leftPoint;
    private float leftx,rightx;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftx=leftPoint.position.x;
        rightx = rightPoint.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // rb.AddForce (Vector2.right * speed);
    }
    public void Move()
    {
        if(faceLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if(transform.position.x<leftx)
            {
                faceLeft=false;
            }
        }
        else{
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if(transform.position.x>rightx)
            {
                faceLeft=true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
	{
		//destroy itself on collision with player (10 = number of "player" layer in this example)
		// if (hit.gameObject.name.Contains("wall")) rb.velocity = new Vector2(-sp).left * speed);

	}
}
