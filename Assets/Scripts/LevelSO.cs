using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "New Level")]
public class LevelSO : ScriptableObject
{
    [Header("Zombie")]
    public float zombieHealth;
    public float zombieSpeed;
    public float zombiePower;
    public float zombieTimes;
    [Header("Marine")]
    public float marinePower;
    public float marineHealth;
    [Header("Tower")]
    public float towerPower;
    public float towerHealth;
    [Header("Barrier")]
    public float barrierHealth;
    [Header("Pay")]
    public int perZombie;
}
