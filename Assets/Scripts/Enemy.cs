using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public bool isBoss;
    public GameObject levelCompleteUI;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health<= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (isBoss)
        {
            levelCompleteUI.SetActive(true);
            Time.timeScale = 0f;
        }
        Destroy(this.gameObject);
        //other death effects
    }
}
