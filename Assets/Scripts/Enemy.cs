using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int enemyType;
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
    public int getHP(){
        return this.health;
    }
    void Die()
    {
        if (isBoss)
        {
            if(SceneManager.GetActiveScene().buildIndex == 3){
                SceneManager.LoadScene(6);
            }else{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
        if (enemyType == 1){
            FindObjectOfType<AudioManager>().Play("WaspDeath");
        }else if(enemyType == 2){
            FindObjectOfType<AudioManager>().Play("MinotaurDeath");
        }else{
            FindObjectOfType<AudioManager>().Play("ScorpianDeath");
        }
        
        Destroy(this.gameObject);
        //other death effects
    }
}
