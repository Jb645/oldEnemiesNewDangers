using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera mainCam;
    private GameObject crosshair;
    private float nextTimeToFire;
    private float fireRate = 15f;

    private WeaponManager weaponManager;

    private void Awake()
    {
        mainCam = Camera.main;
        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    private void Update()
    {
        WeaponShoot();
    }

    private void WeaponShoot()
    {
        if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            weaponManager.shootAnimation();
            BulletFired();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            weaponManager.stopShooting();
        }
    }

    private void BulletFired()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            if (hit.transform.name == "Terrain") return;
            EnemyHealth enemyHealth = hit.transform.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(10);
                Debug.Log("Took damage");
            }

            Debug.Log(hit.transform.name);
        }
    }
}