using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
    private Entity basicEnemy, bossEnemy;
    private PointTracker point;
    private bool bossUnlocked, bossStatsUnlocked;

    [SerializeField]
    private DisplayCost[] costTextArray;

    private int[] costs;

    private void Awake()
    {
        basicEnemy = ScriptableTags.basicEnemyEntity;
        bossEnemy = ScriptableTags.bossEnemyEntity;
        point = ScriptableTags.pointTracker;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == SceneTags.IntroName)
        {
            SetTextValues();
            CheckToSetBossActive();
        }
    }

    private void SetTextValues()
    {
        costTextArray[0].setCostText(point.basicEnemyNumCost);

        costTextArray[1].setCostText(point.basicEnemyDamageCost);

        costTextArray[2].setCostText(point.basicEnemyMaxHealthCost);

        costTextArray[3].setCostText(point.bossEnemyNumCost);

        costTextArray[4].setCostText(point.bossEnemyDamageCost);

        costTextArray[5].setCostText(point.bossEnemyMaxHealthCost);
    }

    public void BuyUgrade(string upgradeType)
    {
        switch (upgradeType)
        {
            case "basicNum":
                costCheck(ref basicEnemy.num, 1, ref point.basicEnemyNumCost, 0);
                break;

            case "basicDamage":
                costCheck(ref basicEnemy.damage, 10, ref point.basicEnemyDamageCost, 1);
                break;

            case "basicMaxHealth":
                costCheck(ref basicEnemy.maxHealth, 50, ref point.basicEnemyMaxHealthCost, 2);
                break;

            case "bossNum":
                if (bossUnlocked)
                    costCheck(ref bossEnemy.num, 1, ref point.bossEnemyNumCost, 3);
                break;

            case "BossDamage":
                if (bossStatsUnlocked)
                    costCheck(ref bossEnemy.damage, 20, ref point.bossEnemyDamageCost, 4);
                break;

            case "bossMaxHealth":
                if (bossStatsUnlocked)
                    costCheck(ref bossEnemy.maxHealth, 100, ref point.bossEnemyMaxHealthCost, 5);
                break;

            default:
                Debug.Log("Wrong Name");
                break;
        }
    }

    private void costCheck(ref int valueIncreased, int increase, ref int cost, int index)
    {
        if (point.currentPoints >= cost)
        {
            Debug.Log($"Bought something");
            valueIncreased += increase;
            point.currentPoints -= cost;
            cost = (int)Mathf.Floor(cost * 1.5f);
            costTextArray[index].setCostText(cost);
            CheckToSetBossActive();
        }
        else
        {
            //code for not working
            Debug.Log("not enough money");
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(SceneTags.Game);
    }

    private void CheckToSetBossActive()
    {
        if (basicEnemy.num >= 5) //if num of basic enemies >=5 unlock bossses
            bossUnlocked = true;
        else bossUnlocked = false;

        SetActiveBosses(3, bossUnlocked); //posible errors

        if (bossEnemy.num > 0 && bossUnlocked) //if number of bosses >0 unlock their stats
            bossStatsUnlocked = true;
        else bossStatsUnlocked = false;
        SetActiveBosses(4, bossStatsUnlocked);
    }

    private void SetActiveBosses(int start, bool action)
    {
        Debug.Log(action);
        for (int i = start; i < costTextArray.Length; i++)
        {
            costTextArray[i].gameObject.SetActive(action);
        }
    }
}