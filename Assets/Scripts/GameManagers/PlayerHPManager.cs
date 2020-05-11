using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    [SerializeField] private int playerHP;

    [SerializeField] private GameplayUIController gameplayUiController;

    //текущее здоровье игрока
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
            GameOver();
        }
    }

    private void GameOver()
    {
        GameInstance.Instance.gameOverUiController.EnableGameOverUI();
            
        Time.timeScale = 0f;
    }
}
