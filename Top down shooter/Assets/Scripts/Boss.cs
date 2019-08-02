using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public int health;
    public Enemy[] enemies;
    public float spawnOffset;
    public int damage;
    public GameObject deathEffect;

    private int halfHealth;
    private Animator anim;

    

    private void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        



    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (health <= halfHealth)
        {
            anim.SetTrigger("Stage2");
        }
                
        // Gör så att den bara spawnar lite då och då. Typ Mod 5

        if (health % 4 == 0)
        {
            Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
            Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

}
