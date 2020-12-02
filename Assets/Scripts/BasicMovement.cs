using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float smoothTime = .1f;
    float smoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if(dir.magnitude >= 0.1)
        {
            float theta = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            float rotationAngle = Mathf.SmoothDampAngle(transform.eulerAngles.z, theta, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);

            controller.Move(dir * speed * Time.deltaTime);
            
        }
    }
}
