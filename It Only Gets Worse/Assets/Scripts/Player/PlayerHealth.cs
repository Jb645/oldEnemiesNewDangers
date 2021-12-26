﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int currentHealth;

    private HealthBar healthBar;

    //set up the scriptable object
    private Entity playerEntity;

    private void Awake()
    {
        healthBar = GameObject.Find("Player Health Bar").GetComponent<HealthBar>();
    }

    private void Start()
    {
        playerEntity = (Entity)Resources.Load("Scriptables/Player");
        maxHealth = playerEntity.maxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        //testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    //made take damage public
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    private void Heal(int healAmount)
    {
        currentHealth += healAmount;
        healthBar.setHealth(currentHealth);
    }
}