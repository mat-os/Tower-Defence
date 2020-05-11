using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private GameplayUIController gameplayUiController;

    public int PlayerGold { get; private set; }

    void Start()
    {
        gameplayUiController.UpdateGoldText(PlayerGold);
    }
    public void AddGold(int goldAmount)
    {
        PlayerGold += goldAmount;

        gameplayUiController.UpdateGoldText(PlayerGold);
    }

    public void SpendGold(int goldAmount)
    {
        PlayerGold -= goldAmount;
        
        gameplayUiController.UpdateGoldText(PlayerGold);
    }


}
