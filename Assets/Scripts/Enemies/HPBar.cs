using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] private TMP_Text HPtext;

    [SerializeField] private Transform HPSliderImage;
    [SerializeField] private Transform FullHPSliderImage;
    
    private float HPNow;

    public void UpdateHPBar(float maxHP, float HPAmount)
    {
        HPNow = HPAmount / maxHP;

        SetFillBar(HPNow);

        HPtext.text = HPAmount.ToString("F0") + "/" + maxHP.ToString("F0");
    }

    void Start()
    {
        //Инициируем HP
        var newScale = this.HPSliderImage.localScale;
        newScale.x = 0;
        this.HPSliderImage.localScale = newScale;
    }

    public void SetFillBar(float fillAmount)
    {
        fillAmount = Mathf.Clamp01(fillAmount);

        var newScale = this.HPSliderImage.localScale;
        newScale.x = this.FullHPSliderImage.localScale.x * fillAmount;
        this.HPSliderImage.localScale = newScale;
    }
}
