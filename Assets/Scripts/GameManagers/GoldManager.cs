using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private GameplayUIController gameplayUiController;
    
    private int playerGold;
    public int PlayerGold => playerGold;

    public void AddGold(int goldAmount)
    {
        playerGold += goldAmount;

        gameplayUiController.UpdateGoldText(playerGold);
    }

    public void SpendGold(int goldAmount)
    {
        playerGold -= goldAmount;
        
        gameplayUiController.UpdateGoldText(playerGold);
    }

    void Start()
    {
        gameplayUiController.UpdateGoldText(playerGold);
    }
}
