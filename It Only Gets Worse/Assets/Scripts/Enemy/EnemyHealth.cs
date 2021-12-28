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
    private PointTracker points;

    private void Start()
    {
        maxHealth = enemyEntity.maxHealth;
        currentHealth = maxHealth;

        damage = enemyEntity.damage;

        deathAnimationTime = enemyEntity.DAT;

        points = (PointTracker)Resources.Load("Scriptables/Point");
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

        if (enemyEntity.type == "Basic")
        {
            points.currentPoints += 10; //will change later
        }
        else if (enemyEntity.type == "Boss")
        {
            points.currentPoints += 100; //will change later
        }

        EnemyCounter.OnEnemyDeath();
        Destroy(this.gameObject, deathAnimationTime);
    }

    //just added everything under--
}