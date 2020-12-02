using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement controls;
    public float moveSpeed = 5f;
    public float smoothTime = .1f;
    float smoothVelocity;
    public Rigidbody2D rb;

    void Awake()
    {
        controls = new PlayerMovement();
    }

    void FixedUpdate()
    {
        Vector2 movementInput = controls.Player.Movement.ReadValue<Vector2>().normalized;
        //Changed the move procedure as well as rotation
        if(movementInput.magnitude >= 0.1)
        {
            float theta = -(Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg);
            float rotationAngle = Mathf.SmoothDampAngle(transform.eulerAngles.z, theta, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.deltaTime);
        }

        //move(movementInput);
    }

    void move(Vector2 movement)
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        float angle;
        if (movement.x < 0)
            angle = (Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg * -1);
        else
            angle = 360 - (Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg);

        rb.MoveRotation(angle);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

}
