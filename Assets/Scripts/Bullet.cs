using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 20;
    public float dieTime;
    public GameObject dieObj;
    void Start()
    {
        Vector3 shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        rb.velocity = shootDirection.normalized * speed;
        //rb.velocity = transform.right * speed;
        //StartCoroutine(CountDownTimer());
        Destroy(this.gameObject, dieTime);
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
                Debug.Log("got here");
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
