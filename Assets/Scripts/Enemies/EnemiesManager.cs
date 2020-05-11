using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField]private EnemyData enemyData;
    
    private EnemyData thisWaveEnemyData;
    public EnemyData ThisWaveEnemyData => thisWaveEnemyData;

    private EnemyAttributes thisWaveEnemyAttributes;
    
    private GameplayUIController gameplayUiController;

    void Start()
    {
        thisWaveEnemyData = Instantiate(enemyData);
        
        thisWaveEnemyAttributes = ThisWaveEnemyData.EnemyAttributes;

        gameplayUiController = GameInstance.Instance.gameplayUiController;
    }

    //Основной метод улучшения противника
    //Проверяем рандомом улучшать все характеристики или только какую-то одну
    public void UpgradeEnemy()
    {
        var rand = Random.Range(0,2);
        
        switch (rand)
        {
            case 0:
                UpgradeRandomAttribute();
                
                break;
            case 1:
                UpgradeAllAttributes();
                
                break;
        }
        
        thisWaveEnemyData.EnemyAttributes = thisWaveEnemyAttributes;

    }

    //Улучшаем рандомный атрибут противника
    private void UpgradeRandomAttribute()
    {
        var rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                thisWaveEnemyAttributes.Damage++;
                
                gameplayUiController.WriteInConsole("Upgrade enemy damage; Damage now :" + thisWaveEnemyAttributes.Damage);
                break;
            case 1:
                thisWaveEnemyAttributes.Hp++;
                
                gameplayUiController.WriteInConsole("Upgrade enemy hp; Hp now :" + thisWaveEnemyAttributes.Hp);
                break;
            case 2:
                thisWaveEnemyAttributes.DurationOfPathTravel--;
                
                gameplayUiController.WriteInConsole("Upgrade enemy speed");
                break;
        }

        thisWaveEnemyAttributes.GoldOnKill++;
    }
    
    //Улучшаем все атрибуты противника
    private void UpgradeAllAttributes()
    {
        thisWaveEnemyAttributes.Damage++;
        thisWaveEnemyAttributes.Hp++;
        thisWaveEnemyAttributes.GoldOnKill++;
        thisWaveEnemyAttributes.DurationOfPathTravel--;
        
        gameplayUiController.WriteInConsole("All Enemy Attributes Upgraded");
    }
}
