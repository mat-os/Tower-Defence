using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float hp;
    [SerializeField]private int damage;
    [SerializeField]private int goldOnKill;
    
    //Здоровье в текущий момент
    private float hpAmount;

    public void InitEnemy(EnemyData enemyData)
    {
        this.hp = enemyData.EnemyAttributes.Hp;
        this.damage = enemyData.EnemyAttributes.Damage;
        this.goldOnKill = enemyData.EnemyAttributes.GoldOnKill;

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
