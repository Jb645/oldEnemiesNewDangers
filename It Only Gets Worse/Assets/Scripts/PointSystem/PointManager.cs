using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
    private Entity basicEnemy, bossEnemy;
    private PointTracker point;

    private void Awake()
    {
        basicEnemy = (Entity)Resources.Load("Scriptables/BasicEnemy");
        bossEnemy = (Entity)Resources.Load("Scriptables/BossEnemy");
        point = (PointTracker)Resources.Load("Scriptables/Point");
    }

    public void BuyUgrade(string upgradeType)
    {
        switch (upgradeType)
        {
            case "basicNum":

                costCheck(ref basicEnemy.num, 1, point.basicEnemyNumCost);
                break;

            case "basicDamage":
                costCheck(ref basicEnemy.damage, 10, point.basicEnemyDamageCost);
                break;

            case "basicMaxHealth":
                costCheck(ref basicEnemy.maxHealth, 50, point.basicEnemyMaxHealthCost);
                break;

            case "bossNum":
                costCheck(ref bossEnemy.num, 1, point.bossEnemyNumCost);
                break;

            case "BossDamage":
                costCheck(ref bossEnemy.damage, 20, point.bossEnemyDamageCost);
                break;

            case "bossMaxHealth":
                costCheck(ref bossEnemy.maxHealth, 100, point.bossEnemyMaxHealthCost);
                break;

            default:
                Debug.Log("Wrong Name");
                break;
        }
    }

    private void costCheck(ref int valueIncreased, int increase, int cost)
    {
        if (point.currentPoints > cost)
        {
            Debug.Log($"Bought something");
            valueIncreased += increase;
            point.currentPoints -= cost;
        }
        else
        {
            //code for not working
            Debug.Log("not enough money");
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
}