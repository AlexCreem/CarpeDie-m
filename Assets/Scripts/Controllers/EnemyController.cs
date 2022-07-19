using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public GameObject player;
    public float damage;
    public float health;
    private Vector2 direction;
    public Rigidbody2D rb;
    private bool lookingLeft;

    public float attackTimer;
    public int attackDamage;
    private float attackCoolCounter;

    public float detectPlayerRange;

    private void Start()
    {
        player = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        lookingLeft = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
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

    private void FixedUpdate()
    {
        if ((target.position - this.transform.position).magnitude < detectPlayerRange)
        {
            move();
            //this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
    private void Update()
    {

        if (target != null)
        {
            getMovement();
            //direction = target.position - this.transform.position;
            //direction = Vector2.MoveTowards(transform.position, target.position, step);
            //probably a better way to do this but leaving for now due to using 2 colliders
            //transform.parent.gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            //rb.MovePosition(rb.position + direction.normalized * Time.deltaTime);

        }
        if (player.transform.position.x < transform.position.x && lookingLeft)
        {
            flip();
        }
        if (player.transform.position.x > transform.position.x && !lookingLeft)
        {
            flip();
        }
    }
    private void flip()
    {
        transform.Rotate(0, 180, 0);
        lookingLeft = !lookingLeft;
    }
    private void getMovement()
    {
        direction = (target.transform.position - this.transform.position).normalized * speed;
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
