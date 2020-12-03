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

    public GameObject tutorial;
    public bool isTutorial = false;

    public int collectible = 0;

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

            if (isTutorial)
            {
                tutorial.GetComponent<TutorialManager>().playerMoved = true;
                isTutorial = false;
            }
        }

    }

    private void OnEnable()
    {
        controls.Enable();
    }

}
