using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightBehaviour : MonoBehaviour
{

    public Light2D light;
    public GameObject exit;
    public GameObject start;
    public Gradient gradient;

    public bool enableBehaviour = true;
    public float timeLimit = 1800;
    public float intensity = 1.5f;

    private float distance;
    private float totalDistance;
    private float currentTime;

    void Start()
    {

        totalDistance = Vector2.Distance(start.transform.position, exit.transform.position);
        currentTime = timeLimit;

        if (!enableBehaviour)
        {
            light.intensity = intensity;
            light.color = gradient.Evaluate(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (enableBehaviour)
        {
            distance = Vector2.Distance(transform.position, exit.transform.position);

            if (distance > totalDistance)
                light.color = gradient.Evaluate(1f);
            else
                light.color = gradient.Evaluate(distance / totalDistance);

            light.intensity = intensity * (currentTime / timeLimit);
            currentTime -= 1;
        }

    }
}