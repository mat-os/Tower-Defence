using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyData :  ScriptableObject
{
    [SerializeField]private EnemyAttributes enemyAttributes;
    public EnemyAttributes EnemyAttributes
    {
        get => enemyAttributes;
        set => enemyAttributes = value;
    }

    //Внешний вид врага
    [SerializeField]private GameObject enemyGO;
    public GameObject EnemyGo => enemyGO;
}

[Serializable]
public struct EnemyAttributes
{
    //Общее кол-во здоровья
    [SerializeField] private float hp;
    
    //Урон врага по базе противника
    [SerializeField] private int damage;
    
    //Сколько золота дают за убийство
    [SerializeField] private int goldOnKill;

    //Время, за которое враг дойдет до конца пути
    [SerializeField] private float durationOfPathTravel;
    public float Hp
    {
        get => hp;
        set => hp = value;
    }

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    public int GoldOnKill
    {
        get => goldOnKill;
        set => goldOnKill = value;
    }

    public float DurationOfPathTravel
    {
        get => durationOfPathTravel;
        set => durationOfPathTravel = value;
    }
}

