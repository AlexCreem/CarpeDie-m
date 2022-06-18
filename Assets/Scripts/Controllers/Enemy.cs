using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public float damage;
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = null;
        }
    }
    private void Update()
    {
        float step = speed * Time.deltaTime;
        if (target != null)
        {
            //probably a better way to do this but leaving for now due to using 2 colliders
            transform.parent.gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
}
