using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightBehaviour : MonoBehaviour
{

    public Light2D light;
    public GameObject exit;
    public GameObject start;
    public GameObject key;
    public Gradient gradient1;
    public Gradient gradient2;

    public bool enableBehaviour = true;
    public bool levelHasKey = true;
    public bool keyCollected = false;

    public float timeLimit = 1800;
    public float intensity = 1.5f;

    private float distance;
    private float totalDistance2Exit;
    private float totalDistance2Key;
    private float currentTime;

    void Start()
    {

        totalDistance2Exit = Vector2.Distance(start.transform.position, exit.transform.position);
        if (levelHasKey)
        {
            totalDistance2Exit = Vector2.Distance(key.transform.position, exit.transform.position);
            totalDistance2Key = Vector2.Distance(start.transform.position, key.transform.position);
        }
        currentTime = timeLimit;

        if (!enableBehaviour && !levelHasKey)
        {
            light.intensity = intensity;
            light.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime <= 0) {
            Debug.Log("Game Over");
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }

        if (enableBehaviour)
        {
            if (levelHasKey)
            {
                
                if (keyCollected)
                {
                    distance = Vector2.Distance(transform.position, exit.transform.position);
                    if (distance > totalDistance2Exit)
                    {
                        light.color = gradient2.Evaluate(1f);
                    }
                    else
                    {
                        light.color = gradient2.Evaluate(distance / totalDistance2Exit);
                    }
                    light.intensity = intensity * (currentTime / timeLimit);
                    currentTime -= 1;
                }else if (!keyCollected)
                {
                    distance = Vector2.Distance(transform.position, key.transform.position);

                    if (distance > totalDistance2Key)
                        light.color = gradient1.Evaluate(1f);
                    else
                        light.color = gradient1.Evaluate(distance / totalDistance2Key);

                    light.intensity = intensity * (currentTime / timeLimit);
                    currentTime -= 1;
                }
            }
            else
            {
                distance = Vector2.Distance(transform.position, exit.transform.position);
                if (distance > totalDistance2Exit)
                {
                    light.color = gradient2.Evaluate(1f);
                }
                else
                {
                    light.color = gradient2.Evaluate(distance / totalDistance2Exit);
                }
                light.intensity = intensity * (currentTime / timeLimit);
                currentTime -= 1;
            }

        }

    }
}