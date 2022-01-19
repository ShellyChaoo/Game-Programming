using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 4;
    private Transform player_Transform;
    Rigidbody rb;
    private bool isGrounded = true;
    private Vector3 origiPos;

    // Start is called before the first frame update
    void Start()
    {
        player_Transform = this.transform;
        rb = GetComponent<Rigidbody>();
        origiPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        playerMovement();
    }

    void playerMovement()
    {
        if (Input.GetButton("Jump"))
        {
            if (isGrounded){
                rb.velocity += new Vector3(0,10,0);
                rb.AddForce(Vector3.up * 10);
                isGrounded = false;
            }
        }
        else {
            //left front
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) {
                player_Transform.localRotation = Quaternion.Euler(0,-45,0);
                player_Transform.Translate(new Vector3(-1,0,1)*speed*Time.deltaTime, Space.World);
            }
            // left back
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) {
                player_Transform.localRotation = Quaternion.Euler(0,-135,0);
                player_Transform.Translate(new Vector3(-1,0,-1)*speed*Time.deltaTime, Space.World);
            }
            // right front
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) {
                player_Transform.localRotation = Quaternion.Euler(0,45,0);
                player_Transform.Translate(new Vector3(1,0,1)*speed*Time.deltaTime, Space.World);
            }
            //right back
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
                player_Transform.localRotation = Quaternion.Euler(0,135,0);
                player_Transform.Translate(new Vector3(1,0,-1)*speed*Time.deltaTime, Space.World);
            }
            else{
                // float moveVertical = Input.GetAxis ("Vertical");
                // rb.velocity = gameObject.transform.forward * speed * moveVertical;
                if (Input.GetKey(KeyCode.A)) {
                    player_Transform.localRotation = Quaternion.Euler(0,-90,0);
                    player_Transform.Translate(Vector3.left*speed*Time.deltaTime, Space.World);
                }
                if (Input.GetKey(KeyCode.D)) {
                    player_Transform.localRotation = Quaternion.Euler(0,90,0);
                    player_Transform.Translate(Vector3.right*speed*Time.deltaTime, Space.World);
                }
                if (Input.GetKey(KeyCode.W)) {
                    player_Transform.localRotation = Quaternion.Euler(0,0,0);
                    player_Transform.Translate(Vector3.forward*speed*Time.deltaTime, Space.World);
                }
                if (Input.GetKey(KeyCode.S)) {
                    player_Transform.localRotation = Quaternion.Euler(0,180,0);
                    player_Transform.Translate(Vector3.back*speed*Time.deltaTime, Space.World);
                }
            }
        }
        
        if (Input.GetKey(KeyCode.R) || player_Transform.localPosition.y<-0.3f) {
            gameObject.transform.position = origiPos;
        }
    }

    void OnCollisionEnter(Collision CollisionObjec){
        isGrounded = true;

    }

    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
