using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Vector2 moveAmount;
    private Rigidbody2D rb;
    public int health;
    private float initSpeed;

    private float slow;

    [Header ("Player Properties")]
    public float speed;
    public int maxHealth;
    public Animator animator;

    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHealth = 100;
        health = maxHealth;
        speed = 5;
        moveAmount = Vector2.zero;
        initSpeed = speed;
        activeMoveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        getMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        move();
        slow = 1;
    }
    private void getMovement()
    {
        //called in update
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        /*commented out for animations to handle direction
        //running left
        if (xMovement < 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        //running right
        else if (xMovement > 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        */
        moveAmount.x = xMovement;
        moveAmount.y = yMovement;
        animator.SetFloat("Horizontal", moveAmount.x);
        animator.SetFloat("Vertical", moveAmount.y);
        animator.SetFloat("Speed", moveAmount.sqrMagnitude);
        moveAmount = moveAmount.normalized* activeMoveSpeed;
    }
    private void move()
    {
        //actually moves rigid body so called in fixed update
        rb.MovePosition(rb.position + moveAmount * Time.deltaTime *slow);
    }
    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("Game Over");
            //OTHER END GAME / DYING STUFF HERE
        }
    }
    public void slowSpeed(float slowAmount)
    {
        this.slow = slowAmount;
        
    }
    public void resetSpeed()
    {
        this.speed = initSpeed;
    }
}
