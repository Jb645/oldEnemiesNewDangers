using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    private static int EnemiesNum;

    private Entity basicEnemy, bossEnemy;
    private PointTracker point;

    private void Awake()
    {
        basicEnemy = ScriptableTags.basicEnemyEntity;
        bossEnemy = ScriptableTags.bossEnemyEntity;
        EnemiesNum = basicEnemy.num + bossEnemy.num;
    }

    public static void OnEnemyDeath()
    {
        EnemiesNum -= 1;

        if (EnemiesNum <= 0)
        {
            SceneManager.LoadScene(SceneTags.Intro);
        }
    }
}