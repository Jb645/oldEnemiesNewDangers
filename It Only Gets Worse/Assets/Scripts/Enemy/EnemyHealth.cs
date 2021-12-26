using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private float deathAnimationTime;

    [SerializeField]
    private int currentHealth;

    private int damage;

    public Entity enemyEntity;

    private void Start()
    {
        maxHealth = enemyEntity.maxHealth;
        currentHealth = maxHealth;

        damage = enemyEntity.damage;

        deathAnimationTime = enemyEntity.DAT;
    }

    private void Update()
    {
        //testing
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //code for death animation

        Destroy(this.gameObject, deathAnimationTime);
    }

    //just added everything under--

    private void OnTriggerEnter(Collider player)
    {
        if (!player.CompareTag("Player")) return;

        dealDamage(player);
    }

    public void dealDamage(Collider player)
    {
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}