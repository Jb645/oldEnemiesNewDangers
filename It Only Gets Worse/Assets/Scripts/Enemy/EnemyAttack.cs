using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Rigidbody enemybody;

    [SerializeField]
    private float hitRate = 15f;

    private float nextTimeToAttack;

    [SerializeField]
    private Entity enemyType;

    private void Start()
    {
        enemybody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.gameObject.CompareTag("Player")) return;

        if (Time.time > nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + 1f / hitRate;
            Debug.Log("you got hit");
            collision.transform.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyType.damage);
        }
    }
}