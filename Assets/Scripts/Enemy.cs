using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int maxHealth = 10;
    public int currentHealth;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 movement;

    public float stoppingDistance;
    //public float retreatHealth;
    public float viewDistance;

    public Transform player;
    public Score score;
  


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(currentHealth <= 0)
        {
            score.UpdateScore(1);
            Destroy(gameObject);
            
        }

        float distance = Vector2.Distance(transform.position, player.position);
        Vector2 direction = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        if (distance > stoppingDistance && distance <= viewDistance)
        {
            direction = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(direction);

            float theta = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = theta;
            
        }else if (Vector2.Distance(transform.position, player.position) <= stoppingDistance)
        {

            rb.MovePosition(transform.position);
            float theta = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = theta;

        }
        else if(distance > viewDistance)
        {
            //kept as separate else if for later patrol implementation
            rb.MovePosition(transform.position);
            rb.rotation = 0;
        }

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
