using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private float damage;
    public float Damage => damage;

    [SerializeField] private float attackRate;
    public float AttackRate => attackRate;
    
    [SerializeField]private float attackRange;
    public float AttackRange => attackRange;
    
    [Header("Cost Settings")]
    [SerializeField]private int costOfUpgrade;
    public int CostOfUpgrade => costOfUpgrade;
    
    private int level = 1;
    public int Level => level;

    //Улучшаем характеристики башни
    public void UpgradeTower(float levelupCoefficient)
    {
        level++;

        damage *= levelupCoefficient;
        attackRate *= levelupCoefficient;
        attackRange *= levelupCoefficient;
        
        costOfUpgrade += costOfUpgrade;
    }
}
