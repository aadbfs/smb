using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public float jump_Force;
    public float forward_force;
    public float max_speed = 5;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (isGrounded())
        {
            if (Input.GetKey(KeyCode.LeftArrow) && !atMaxVelocity())
            {
                rb.AddForce(new Vector2(-1 * forward_force, 0));
            }

            if (Input.GetKey(KeyCode.RightArrow) && !atMaxVelocity())
            {
                rb.AddForce(new Vector2(forward_force, 0));
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true)
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
        if(hit.distance < 0.05f)
        {
            return true;
        }
        return false;
    }

    private bool atMaxVelocity()
    {
        if(Mathf.Abs(rb.velocity.x) < max_speed)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
