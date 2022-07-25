using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float attackTimer;
    private float attackCoolCounter;

    // Update is called once per frame
    void Update()
    {
        if (attackCoolCounter <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                FindObjectOfType<AudioManager>().Play("PlayerShoot");
                Shoot();
                attackCoolCounter = attackTimer;
            }
        }
        if (attackCoolCounter > 0)
        {
            attackCoolCounter -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    public void setAttackSpeed(float attackSpeed)
    {
        attackTimer = attackSpeed;
    }
}
