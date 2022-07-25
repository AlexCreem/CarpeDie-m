using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public float dashLength;
    public float dashCooldown;
    private float dashCounter;
    private float dashCoolCounter;

    private int currentScene;

    public GameObject gameOverUI;

    public Weapon weapon;
    public float rapidLength;
    public float rapidCooldown;
    private float rapidCounter;
    private float rapidCoolCounter;
    public float baseAttackSpeed;

    public float immuneLength;
    public float immuneCooldown;
    private float immuneCounter;
    private float immuneCoolCounter;
    private bool immune;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        speed = 5;
        moveAmount = Vector2.zero;
        initSpeed = speed;
        activeMoveSpeed = speed;
        immune = false;
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        getMovement();


        //stage 1 ability
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                FindObjectOfType<AudioManager>().Play("Dash");
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

        if (currentScene >= 2)
        {
            //stage 2 ability
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (rapidCoolCounter <= 0 && rapidCounter <= 0)
                {
                    FindObjectOfType<AudioManager>().Play("RapidFire");
                    weapon.setAttackSpeed(0);
                    rapidCounter = rapidLength;
                }
            }
            if (rapidCounter > 0)
            {
                rapidCounter -= Time.deltaTime;

                if (rapidCounter <= 0)
                {
                    weapon.setAttackSpeed(baseAttackSpeed);
                    rapidCoolCounter = rapidCooldown;
                }
            }
            if (rapidCoolCounter > 0)
            {
                rapidCoolCounter -= Time.deltaTime;
            }

        }

        if (currentScene >= 3)
        {
            //stage 3 ability
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (immuneCoolCounter <= 0 && immuneCounter <= 0)
                {
                    FindObjectOfType<AudioManager>().Play("Immunity");
                    immune = true;
                    immuneCounter = immuneLength;
                }
            }
            if (immuneCounter > 0)
            {
                immuneCounter -= Time.deltaTime;

                if (immuneCounter <= 0)
                {
                    immune = false;
                    immuneCoolCounter = immuneCooldown;
                }
            }
            if (immuneCoolCounter > 0)
            {
                immuneCoolCounter -= Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        if (moveAmount.x == 0 && moveAmount.y == 0){
            FindObjectOfType<AudioManager>().Play("PlayerWalking");
        }
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
        if (!immune)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            health -= amount;
            if (health <= 0)
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene(4);
                
            }
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

    public string getPlayerHP(){
        return "HP: " + this.health;
    }
}
