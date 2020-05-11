using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    [Header("Player Managers")]
    public GoldManager goldManager;
    public PlayerHPManager playerHpManager;
    
    [Header("Gameplay Managers")]
    public GameplayManager gameplayManager;
    
    [Header("UI Managers")]
    public UpgradeTowerUIController upgradeTowerUiController;
    public GameplayUIController gameplayUiController;
    
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
