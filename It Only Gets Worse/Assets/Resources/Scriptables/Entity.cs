using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class Entity : ScriptableObject
{
    [Header("-Identity-")]
    public new string name;

    public string type;

    [Header("-Stats-")]
    public int damage;

    public int maxHealth;
    public int speed_walking;
    public int speed_running;

    [Header("-Animation-")]
    [Tooltip("Death Animation Time, how long does the death animation take?")]
    public float DAT;

    public int num;
}