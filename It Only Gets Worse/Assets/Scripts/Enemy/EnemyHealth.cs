using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    //animaton script
    [SerializeField] private EnemyAnimation enemyAnimation;

    //enemy controller
    [SerializeField] private EnemyController enemyController;

    //enemy health bar
    [SerializeField] private EnemyHealthBar enemyHealthBar;

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

        points = ScriptableTags.pointTracker;
    }

    private void Update()
    {
        //testing
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (enemyHealthBar != null)
        {
            enemyHealthBar.healthSlider.value -= damage;
        }

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
        //stops the enemy

        if (enemyController != null) //checks if they exist
        {
            enemyController.enabled = false;
            enemyAnimation.SetDie();
        }

        if (this.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject, deathAnimationTime);
        }
        else //for basic
        {
            Destroy(this.transform.parent.parent.gameObject, deathAnimationTime);
        }
    }

    //just added everything under--

    private void OnTriggerEnter(Collider player)
    {
        if (!player.CompareTag("Player")) return;
        dealDamage(player);
    }

    public void dealDamage(Collider player)
    {
        Debug.Log("called");
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}