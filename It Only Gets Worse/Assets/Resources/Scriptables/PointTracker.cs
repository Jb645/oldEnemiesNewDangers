using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tracker", menuName = "Tracker")]
public class PointTracker : ScriptableObject
{
    public int currentPoints;

    [Header("Basic Enemies")]
    public int basicEnemyKill;

    public int basicEnemyDamageCost, basicEnemyMaxHealthCost, basicEnemyNumCost;

    [Header("Boss Enemies")]
    public int bossEnemyKill;

    public int bossEnemyNumCost, bossEnemyDamageCost, bossEnemyMaxHealthCost;
}