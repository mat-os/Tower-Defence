using UnityEngine;

public class GameInstance : MonoBehaviour
{
    [Header("Player Managers")]
    public GoldManager goldManager;
    public PlayerHPManager playerHpManager;
    
    [Header("UI Managers")]
    public UpgradeTowerUIController upgradeTowerUiController;
    public GameplayUIController gameplayUiController;
    public GameOverUIController gameOverUiController;
    
    [Header("Statistic Manager")]
    public StatisticCollector statisticCollector;

    #region Awake
    public static GameInstance Instance;

    void Awake()
    {
        if (Instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
