using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float hp;
    [SerializeField]private int damage;
    [SerializeField]private int goldOnKill;
    [SerializeField]private float durationOfPathTravel;
    public float DurationOfPathTravel => durationOfPathTravel;
    
    //Здоровье в текущий момент
    private float hpAmount;

    public void InitEnemy(EnemyData enemyData)
    {
        var enemyAttributes = enemyData.EnemyAttributes;
        
        this.hp = enemyAttributes.Hp;
        this.damage = enemyAttributes.Damage;
        this.goldOnKill = enemyAttributes.GoldOnKill;
        this.durationOfPathTravel = enemyAttributes.DurationOfPathTravel;

        hpAmount = hp;
    }

    public void ApplyDamage(float damageAmount)
    {
        hpAmount -= damageAmount;

        if (hpAmount <= 0)
        {
            Dead();
        }
    }

    public void DealDamage()
    {
        GameInstance.Instance.playerHpManager.ApplyDamage(damage);
        Destroy(this.gameObject);
    }

    private void Dead()
    {
        SpawnEnemiesSystem.enemiesOnLevel.Remove(this.gameObject);
        
        GameInstance.Instance.goldManager.AddGold(goldOnKill);
        GameInstance.Instance.statisticCollector.AddKillToStatistic();
        
        Destroy(gameObject);
    }
}
