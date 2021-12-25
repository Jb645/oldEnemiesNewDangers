using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class Entity : ScriptableObject
{
    public new string name;
    public string type;

    public int damage;
    public int maxHealth;
    public int speed_walking;
    public int speed_running;
}