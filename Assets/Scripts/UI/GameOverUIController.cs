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
}
