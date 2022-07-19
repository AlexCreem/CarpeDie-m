using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public GameObject player;
    public float damage;
    public float health;
    private Vector2 direction;
    public float playerDetectRange;
    public Rigidbody2D rb;
    public float range;
    public GameObject projectile;
    public float shootSpeed;
    public Transform shootPos;
    private float distToPlayer;
    private float initSpeed;
    private bool canShoot;
    private bool lookingLeft;

    public float attackTimer;
    private float attackCoolCounter;

    private void Start()
    {
        initSpeed = speed;
        player = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        canShoot = true;
        lookingLeft = false;
    }

    private void FixedUpdate()
    {
        if ((target.position - this.transform.position).magnitude < playerDetectRange)
        {
            move();
            //this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
    private void shoot()
    {
        canShoot = false;
        GameObject newBullet = Instantiate(projectile, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        canShoot = true;


    }
    private void Update()
    {
        if (attackCoolCounter <= 0)
        {
            canShoot = true;
            attackCoolCounter = attackTimer;
        }
        if (attackCoolCounter > 0)
        {
            attackCoolCounter -= Time.deltaTime;
        }
        distToPlayer = Vector2.Distance(transform.position, target.position);
        if(distToPlayer <= range)
        {
            speed = 0f;
            if (canShoot)
            {
                shoot();
                canShoot = false;
            }
            
        }
        else
        {
            speed = initSpeed;
        }

        if (player.transform.position.x < transform.position.x && lookingLeft)
        {
            flip();
        }
        if (player.transform.position.x > transform.position.x && !lookingLeft)
        {
            flip();
        }

        if (target != null)
        {
            getMovement();
            //direction = target.position - this.transform.position;
            //direction = Vector2.MoveTowards(transform.position, target.position, step);
            //probably a better way to do this but leaving for now due to using 2 colliders
            //transform.parent.gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            //rb.MovePosition(rb.position + direction.normalized * Time.deltaTime);

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
