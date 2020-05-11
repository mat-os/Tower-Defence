using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TMP_Text KillsStatText;

    public void EnableGameOverUI()
    {
        gameOverUI.SetActive(true);

        KillsStatText.text = GameInstance.Instance.statisticCollector.KilledEnemies.ToString();
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        DOTween.KillAll();
    }
}
