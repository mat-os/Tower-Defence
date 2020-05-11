using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerUpgradeController : MonoBehaviour
{
    //Коэффициент на который повышаются характеристики при апгрейде.
    [SerializeField] private float levelupCoefficient;

    [SerializeField] private UnityEvent upgradeTowerEvent;
    
    private Tower thisTower;

    private GoldManager goldManager;

    #region MonoBehaviour
    private void OnValidate()
    {
        if (levelupCoefficient <= 1)
        {
            levelupCoefficient = 1;
        }
    }
    #endregion

    void Start()
    {
        thisTower = GetComponent<Tower>();

        goldManager = GameInstance.Instance.goldManager;
    }
    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (goldManager.PlayerGold >= thisTower.CostOfUpgrade)
            {
                UpgradeTower();
            }
            
            else if (goldManager.PlayerGold < thisTower.CostOfUpgrade)
            {
                GameInstance.Instance.upgradeTowerUiController.ShakeUI();
            }
        }
    }

    void UpgradeTower()
    {
        goldManager.SpendGold(thisTower.CostOfUpgrade);
        
        thisTower.UpgradeTower(levelupCoefficient);
        
        GameInstance.Instance.upgradeTowerUiController.UpdateTowerAttributes(thisTower);

        upgradeTowerEvent.Invoke();
    }
}
