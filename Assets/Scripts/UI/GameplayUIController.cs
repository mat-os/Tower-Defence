using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text HPAmountText;
    [SerializeField] private TMP_Text goldAmountText;

    [SerializeField] private TMP_Text waveText;
    
    [SerializeField] private TMP_Text consoleText;
    
    public void UpdateGoldText(int goldAmount)
    {
        goldAmountText.text = goldAmount.ToString();
    }

    public void UpdateHPText(int HPamount)
    {
        HPAmountText.text = HPamount.ToString();
    }

    public void UpdateWaveText(int levelNow)
    {
        waveText.text = levelNow.ToString();
    }

    public void WriteInConsole(string textToWrite)
    {
        consoleText.DOFade(1, 0);
        consoleText.DOFade(0, 4f);
        
        consoleText.text = textToWrite;
    }
}
