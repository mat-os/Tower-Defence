using UnityEngine;

public class SelectTower : MonoBehaviour
{
    [SerializeField]private GameObject lightObj;
    
    private Tower thisTower;

    private void Start()
    {
        thisTower = GetComponent<Tower>();
    }

    private void OnMouseEnter()
    {
        GameInstance.Instance.upgradeTowerUiController.UpdateTowerAttributes(thisTower);
        
        lightObj.SetActive(true);
    }
    private void OnMouseOver()
    {
        GameInstance.Instance.upgradeTowerUiController.ShowUI(true);
        GameInstance.Instance.upgradeTowerUiController.UpdateCostField(thisTower);
    }
    private void OnMouseExit()
    {
        GameInstance.Instance.upgradeTowerUiController.ShowUI(false);
        
        lightObj.SetActive(false);
    }
}
