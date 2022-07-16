using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSlow : MonoBehaviour
{
    public float slowAmount;
    private int n = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.slowSpeed(slowAmount);
        }
    }



}
