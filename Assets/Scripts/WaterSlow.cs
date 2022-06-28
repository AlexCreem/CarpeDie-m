using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSlow : MonoBehaviour
{
    public float slowAmount;
    private int n = 0;

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.slowSpeed(slowAmount);
            n++;
            Debug.Log(n);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            Player player = collision.GetComponent<Player>();
            n--;
            if (n == 0)
                player.resetSpeed();
            Debug.Log(n);
        }
    }
    */

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.slowSpeed(slowAmount);
        }
    }



}
