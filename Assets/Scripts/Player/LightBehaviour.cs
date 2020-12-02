using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightBehaviour : MonoBehaviour
{

    public Light2D light;
    public GameObject exit;
    public GameObject player;
    public GameObject key;
    public Gradient gradient1;
    public Gradient gradient2;

    public bool enableColour = true;
    public bool enableIntensity = true;
    public bool levelHasKey = true;
    public bool keyCollected = false;

    public float timeLimit = 1800;
    public float timeToLose = 200;
    public float intensity = 1.5f;

    private float distance;
    private float distanceToKey;
    private float distanceToExit;
    private float currentTime;

    public GameObject levelFailedUI;

    void Start()
    {

        if (!levelHasKey)
            distanceToExit = Vector2.Distance(player.transform.position, exit.transform.position);
        else
        {
            distanceToKey = Vector2.Distance(player.transform.position, key.transform.position);
            distanceToExit = Vector2.Distance(key.transform.position, exit.transform.position);
        }

        currentTime = timeLimit;

        if (!enableColour)
            light.color = Color.white;

        if (!enableIntensity)
            light.intensity = intensity;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0)
        {
            FindObjectOfType<SoundManager>().Play("Fail");
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            levelFailedUI.SetActive(true);
        }

        if (enableColour && enableIntensity)
        {
            if (levelHasKey)
            {
                if (keyCollected)
                {
                    distance = Vector2.Distance(transform.position, exit.transform.position);

                    if (distance > distanceToExit)
                        light.color = gradient2.Evaluate(1f);
                    else
                        light.color = gradient2.Evaluate(distance / distanceToExit);

                    light.intensity = intensity * (currentTime / timeLimit);
                    currentTime -= 1;
                }

                else
                {
                    distance = Vector2.Distance(transform.position, key.transform.position);

                    if (distance > distanceToKey)
                        light.color = gradient1.Evaluate(1f);
                    else
                        light.color = gradient1.Evaluate(distance / distanceToKey);

                    light.intensity = intensity * (currentTime / timeLimit);
                    currentTime -= 1;
                }
            }
            else
            {
                distance = Vector2.Distance(transform.position, exit.transform.position);

                if (distance > distanceToExit)
                    light.color = gradient2.Evaluate(1f);
                else
                    light.color = gradient2.Evaluate(distance / distanceToExit);

                light.intensity = intensity * (currentTime / timeLimit);
                currentTime -= 1;

            }
        }

    }
}