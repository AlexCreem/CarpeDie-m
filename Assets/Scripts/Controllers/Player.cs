using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Vector2 moveAmount;
    private Rigidbody2D rb;
    private int health;

    [Header ("Player Properties")]
    public float speed;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHealth = 3;
        health = maxHealth;
        speed = 5;
        moveAmount = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        getMovement();
    }

    private void FixedUpdate()
    {
        move();
    }
    private void getMovement()
    {
        //called in update
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

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

        moveAmount.x = xMovement;
        moveAmount.y = yMovement;
        moveAmount = moveAmount.normalized* speed;
    }
    private void move()
    {
        //actually moves rigid body so called in fixed update
        rb.MovePosition(rb.position + moveAmount * Time.deltaTime);
    }
    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
