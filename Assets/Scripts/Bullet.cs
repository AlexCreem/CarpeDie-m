using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 shootDirection;
    public float speed;
    public Rigidbody2D rb;
    public int damage = 20;
    public float dieTime;
    public GameObject dieObj;


    void Start()
    {
        shootDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        shootDirection.z = 0f;
        shootDirection = shootDirection.normalized * speed;
        //rb.velocity = shootDirection.normalized * speed;
        Destroy(this.gameObject, dieTime);
        
    }
    private void FixedUpdate()
    {
        // rb.MovePosition(rb.position + shootDirection * Time.deltaTime);
        transform.position += shootDirection * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (!collision.name.Equals("Player"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(this.gameObject);
            }

            Debug.Log(collision.name);
        }
        /*
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        Debug.Log(collision.name);
        */
       //Destroy(this.gameObject);
    }


}
