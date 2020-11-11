using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightBehaviour : MonoBehaviour
{

    public Light2D light;
    public GameObject exit;
    float distance;
    public Gradient gradient;

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, exit.transform.position);

        Debug.Log(distance);
        
        light.color = gradient.Evaluate(distance);
    }
}
