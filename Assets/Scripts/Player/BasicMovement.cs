using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    //public variables
    public float speed = 5f, torque = 0f;
    public Vector2 maxVelocity;
    public Rigidbody2D rb;
    public Camera cam;

    //private variables
    private Vector2 movement;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }


    private void FixedUpdate()
    {

        Debug.Log(movement);
        if(movement != Vector2.zero)
        {
            
            //rb.AddForce(new Vector2(movement.x * speed, movement.y * speed));
            rb.MovePosition(rb.position + (movement * speed) * Time.deltaTime);
        }

        else
        {
            rb.velocity -= 0.05f * rb.velocity;
        }

    }

 
}
