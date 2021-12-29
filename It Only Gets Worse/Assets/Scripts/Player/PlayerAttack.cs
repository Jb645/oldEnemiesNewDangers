using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera mainCam, fpsCam;
    private GameObject crosshair;
    private float nextTimeToFire;
    private float fireRate = 15f;

    private WeaponManager weaponManager;

    private void Awake()
    {
        mainCam = Camera.main;
        fpsCam = GetComponentInChildren<Camera>();
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
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

            EnemyHealth enemyHealth = hit.transform.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(10);
                Debug.Log("Enemy Took damage");
            }
            else
            {
                Debug.Log("null enemy Health");
            }

            Debug.Log(hit.transform.name);
        }
    }
}