using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float dieTime;
    public int damage;
    public GameObject dieObj;
    public Player player;
    void Start()
    {
        Destroy(this.gameObject, dieTime);
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name.Equals("Player"))
        {
            Die();
            player.takeDamage(damage);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
