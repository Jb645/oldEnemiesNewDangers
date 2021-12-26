using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera mainCam;
    private GameObject crosshair;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        WeaponShoot();
    }

    private void WeaponShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BulletFired();
        }
    }

    private void BulletFired()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            EnemyHealth enemyHealth = hit.transform.gameObject.GetComponentInParent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(10);
            }
        }
    }
}