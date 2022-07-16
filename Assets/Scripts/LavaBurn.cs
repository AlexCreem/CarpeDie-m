using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBurn : MonoBehaviour
{
    public float slowAmount;

    public GameObject player;

    public float burnTimer;
    public int burnDamage;
    private float burnCoolCounter;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.slowSpeed(slowAmount);

            if (burnCoolCounter <= 0)
            {
                player.GetComponent<Player>().takeDamage(burnDamage);
                burnCoolCounter = burnTimer;
                //Debug.Log("player should take damage");
            }
            if (burnCoolCounter > 0)
            {
                burnCoolCounter -= Time.deltaTime;
            }
        }
    }
    
}
