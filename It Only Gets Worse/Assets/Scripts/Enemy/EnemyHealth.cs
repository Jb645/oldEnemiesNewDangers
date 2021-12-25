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

    public Entity enemyEntity;

    private void Start()
    {
        maxHealth = enemyEntity.maxHealth;
        currentHealth = maxHealth;

        deathAnimationTime = enemyEntity.DAT;
    }

    private void Update()
    {
        //testing
        Testing();
    }

    private void Testing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            takeDamage(10);
        }
    }

    private void takeDamage(int damage)
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
}