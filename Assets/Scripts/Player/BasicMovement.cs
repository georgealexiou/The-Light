using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{


    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;


    private Vector2 movement;
    private Vector2 mousePos;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Magnitude", movement.magnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);


    }

 
}
