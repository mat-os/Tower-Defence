using TMPro;
using UnityEngine;

public class UpgradeTowerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text dmgText;
    [SerializeField] private TMP_Text arText;
    [SerializeField] private TMP_Text costText;
    
    public void UpdateTextField(Tower tower)
    {
        nameText.text = tower.gameObject.name;
        levelText.text = tower.Level.ToString("F0");
        dmgText.text = tower.Damage.ToString("F1");
        arText.text = tower.AttackRate.ToString("F1");
        costText.text = tower.CostOfUpgrade.ToString("F0");
    }
}
