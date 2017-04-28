using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public float distToGround;
    public float jump_Force;
    public float forward_force;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isGrounded())
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(new Vector2(-1 * forward_force, 0));
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(new Vector2(forward_force, 0));
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded() == true)
            {
                Vector2 forceToAdd = Vector2.up * jump_Force + rb.velocity;
                Debug.Log("Velocity: " + rb.velocity);
                Debug.Log(rb.position);
                rb.AddForce(Vector2.up * jump_Force + rb.velocity);
                Debug.Log(forceToAdd);
            }
        }        
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), -Vector2.up);
        if(hit.distance < 0.3f)
        {
            return true;
        }
        return false;
    }
}
