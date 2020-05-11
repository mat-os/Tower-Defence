using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private GameOverUIController gameOverUi;
    public void GameOver()
    {
        gameOverUi.EnableGameOverUI();
        
        Time.timeScale = 0;
    }
}
