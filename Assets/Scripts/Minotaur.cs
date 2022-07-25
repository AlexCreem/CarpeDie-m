using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public GameObject player;
    public float damage;
    public float health;
    private Vector2 direction;
    public Rigidbody2D rb;
    private bool isCharging;
    public float detectRange;
    public float chargeRange;

    private float activeMoveSpeed;
    public float chargeSpeed;
    public float chargeLength = 0.5f;
    public float chargeCooldown = 1f;
    private float chargeCounter;
    private float chargeCoolCounter;
    private bool lookingLeft;

    public float attackTimer;
    public int attackDamage;
    private float attackCoolCounter;

    private void Start()
    {
        player = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isCharging = false;
        activeMoveSpeed = speed;
        lookingLeft = false;
    }
    private void flip()
    {
        transform.Rotate(0, 180, 0);
        lookingLeft = !lookingLeft;
    }

    private void FixedUpdate()
    {
        if (attackCoolCounter > 0)
        {
            attackCoolCounter -= Time.deltaTime;
        }




        float distance = (target.position - this.transform.position).magnitude;
        if (distance < detectRange && distance > chargeRange)
        {
            if (player.transform.position.x < transform.position.x && lookingLeft)
            {
                flip();
            }
            if (player.transform.position.x > transform.position.x && !lookingLeft)
            {
                flip();
            }
            getMovement();
            move();
            //this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        else if (distance < chargeRange && chargeCoolCounter <= 0)
        {
            //charge();
            if (isCharging == false)
            {
                direction = (target.transform.position - this.transform.position).normalized * chargeSpeed;
            }

            activeMoveSpeed = chargeSpeed;
            chargeCounter = chargeLength;


            if (chargeCounter > 0)
            {
                chargeCounter -= Time.deltaTime;
                isCharging = true;

                if (chargeCounter <= 0)
                {
                    activeMoveSpeed = speed;
                    chargeCoolCounter = chargeCooldown;
                    isCharging = false;
                    getMovement();
                }
            }
            if (chargeCoolCounter > 0)
            {
                chargeCoolCounter -= Time.deltaTime;
            }
            move();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isCharging)
            {
                if (attackCoolCounter <=0)
                {
                    FindObjectOfType<AudioManager>().Play("MinotaurNoise");
                    player.GetComponent<Player>().takeDamage(attackDamage);
                    attackCoolCounter = attackTimer;
                }
            }
        }
    }
    private void Update()
    {

        if (target != null && isCharging == false)
        {
            getMovement();
            //direction = target.position - this.transform.position;
            //direction = Vector2.MoveTowards(transform.position, target.position, step);
            //probably a better way to do this but leaving for now due to using 2 colliders
            //transform.parent.gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            //rb.MovePosition(rb.position + direction.normalized * Time.deltaTime);

        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (attackCoolCounter <= 0)
            {
                player.GetComponent<Player>().takeDamage(attackDamage);
                attackCoolCounter = attackTimer;
                Debug.Log("player should take damage");
            }
            if (attackCoolCounter > 0)
            {
                attackCoolCounter -= Time.deltaTime;
            }
        }
    }
    */
    private void getMovement()
    {
        direction = (target.transform.position - this.transform.position).normalized * activeMoveSpeed;
        //anim.SetFloat("Speed", 1);
        //anim.SetFloat("Horizontal", direction.x);
        //probably going to have to not use animations on enemies because the pack didn't come with animations and there are many bugs trying to make our own
    }
    private void move()
    {
        //actually moves rigid body so called in fixed update
        rb.MovePosition(rb.position + direction * Time.deltaTime);
    }
    public Vector2 getDirection()
    {
        return this.direction;
    }
    
}
