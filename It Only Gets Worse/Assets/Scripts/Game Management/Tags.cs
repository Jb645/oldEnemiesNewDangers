using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags
{
    public const string crosshair = "crosshair";
}

public class UpgradeTags
{
    public const string basicEnemyNum = "basicEnemyNum";
}

public class ScriptableTags
{
    public const string basicEnemyAddress = "Scriptables/BasicEnemy";
    public const string bossEnemyAddress = "Scriptables/BossEnemy";
    public const string pointAddress = "Scriptables/Point";

    public static Entity basicEnemyEntity = (Entity)Resources.Load(basicEnemyAddress);
    public static Entity bossEnemyEntity = (Entity)Resources.Load(bossEnemyAddress);
    public static PointTracker pointTracker = (PointTracker)Resources.Load(pointAddress);
}

public class SceneTags
{
    public const string Game = "Scenes/Game";
    public const string Intro = "Scenes/Intro";
    public const string IntroName = "Intro";
}

public class AnimationTags
{
    public const string Shoot = "Shoot";
}