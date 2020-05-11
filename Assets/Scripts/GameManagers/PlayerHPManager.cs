using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    [SerializeField] private int playerHP;

    [SerializeField] private GameplayUIController gameplayUiController;

    private int playerHPamount;
    
    void Start()
    {
        playerHPamount = playerHP;
        
        gameplayUiController.UpdateHPText(playerHPamount);
    }
    
    public void ApplyDamage(int damage)
    {
        playerHPamount -= damage;
        gameplayUiController.UpdateHPText(playerHPamount);

        if (playerHPamount <= 0)
        {
            GameInstance.Instance.gameplayManager.GameOver();
        }
    }
}
