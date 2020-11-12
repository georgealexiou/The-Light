using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement controls;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    void Awake()
    {
        controls = new PlayerMovement();
    }

    void Update()
    {
        Vector2 movementInput = controls.Player.Movement.ReadValue<Vector2>();
        move(movementInput);
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
