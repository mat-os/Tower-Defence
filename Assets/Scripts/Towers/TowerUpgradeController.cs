using UnityEngine;
using UnityEngine.Events;

public class TowerUpgradeController : MonoBehaviour
{
    //Коэффициент на который повышаются характеристики при апгрейде.
    [SerializeField] private float levelupCoefficient;

    //Евент для визуального эффекта при улучшении башни
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
            //Если хватает денег- улучшаем
            if (goldManager.PlayerGold >= thisTower.CostOfUpgrade)
            {
                UpgradeTower();
            }
            
            //Если не хватает денег- потрясываем UI
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
