using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UpgradeTowerUIController : MonoBehaviour
{
    [SerializeField] private UpgradeTowerUI towerUpgradeUI;

    [SerializeField] private GameObject clickToUpgrade;
    [SerializeField] private GameObject notEnoughtMoney;

    private GoldManager goldManager;
    
    void Start()
    {
        goldManager = GameInstance.Instance.goldManager;
    }
    
    //Показываем или убираем окошко статистики при наведении на баншню
    public void ShowUI(bool isShow)
    {
        switch (isShow)
        {
            case true:
                towerUpgradeUI.gameObject.SetActive(true);
                towerUpgradeUI.transform.position = Input.mousePosition;
                
                break;
            
            case false:
                towerUpgradeUI.gameObject.SetActive(false);
                
                break;
        }
    }
    
    //Проверяем, хватает ли денег для улучшение башни
    public void UpdateCostField(Tower tower)
    {
        if (goldManager.PlayerGold >= tower.CostOfUpgrade)
        {
            clickToUpgrade.SetActive(true);
            notEnoughtMoney.SetActive(false);
        }
        else if (goldManager.PlayerGold < tower.CostOfUpgrade)
        {
            clickToUpgrade.SetActive(false);
            notEnoughtMoney.SetActive(true);
        }
    }
    
    //Обновляем текст на UI
    public void UpdateTowerAttributes(Tower tower)
    {
        towerUpgradeUI.UpdateTextField(tower);
    }

    //Эффект тряски UI когда не хватает монеток на улучшение
    public void ShakeUI()
    {
        towerUpgradeUI.gameObject.transform.DOShakePosition(0.3f, 5, 15);
    }
}
