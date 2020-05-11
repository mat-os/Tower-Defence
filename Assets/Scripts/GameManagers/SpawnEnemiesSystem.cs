using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesSystem : MonoBehaviour
{
    [SerializeField]private LevelSettings levelSettings;
    
    [SerializeField]private float timeBetweenEnemies;

    [SerializeField]private EnemiesManager enemiesManager;
    
    //Лист в который добавляются все враги на уровне
    public static readonly List<GameObject> enemiesOnLevel = new List<GameObject>();
    //Поиск врагов можно было сделать через GameObject.FindWithTag() или через коллайдеры
    //Но я подумал, что лучше собрать всех врагов в список при спавне
    
    private LevelData thisLevelData;
    
    private int waveCounter;
    private int enemyCounter;
    private int enemiesOnThisLevel;
    
    private float timer;

    private bool readyToStartNewWave;
    private bool isNewLevelRoutineStart;

    private GameObject enemiesPatern;
    void Start()
    {
        //Получаем настройки уровня из LevelSettings
        thisLevelData = levelSettings.LevelData;
        
        //GO который будет родителем для врагов
        enemiesPatern = GameObject.Find("Enemies");
    }
    
    void Update()
    {
        //Если всё готово- спавним врагов
        if (readyToStartNewWave && enemyCounter < enemiesOnThisLevel)
        {
            timer += Time.deltaTime;

            if (timer > timeBetweenEnemies)
            {
                SpawnEnemie();
                
                timer = 0;
            }
        }
        //Иначе запускам подготовку новой волны
        else if(!isNewLevelRoutineStart)
        {
            readyToStartNewWave = false;
            
            StartCoroutine(StartNewWaveRoutine());

            isNewLevelRoutineStart = true;
        }
    }
    
    //Корутина подготовки новой волны
    IEnumerator StartNewWaveRoutine()
    {
        waveCounter++;
        
        enemiesOnThisLevel = Random.Range(waveCounter, waveCounter + thisLevelData.MaxRandomEnemiesInWave + 1);

        float t = 0;
        while (t < thisLevelData.TimeBetweenWaves)
        {
            t += Time.deltaTime;

            yield return null;
        }

        enemyCounter = 0;
        readyToStartNewWave = true;
        
        //Улучшение характеристик противников
        if (waveCounter > 1)
        {
            enemiesManager.UpgradeEnemy();
        }
        
        //Обновление UI
        GameInstance.Instance.gameplayUiController.UpdateWaveText(waveCounter);

        isNewLevelRoutineStart = false;
        StopAllCoroutines();
    }
    
    //Метод для спавна врага
    private void SpawnEnemie()
    {
        var newEnemy = Instantiate(enemiesManager.ThisWaveEnemyData.EnemyGo, WaypointSystem.points[0], Quaternion.identity);
        newEnemy.GetComponent<Enemy>().InitEnemy(enemiesManager.ThisWaveEnemyData);
        
        newEnemy.name = ($"{newEnemy.name}_{waveCounter}_{enemyCounter}");
        newEnemy.transform.parent = enemiesPatern.transform;

        enemiesOnLevel.Add(newEnemy);
        
        enemyCounter++;
    }

    private void OnDisable()
    {
        enemiesOnLevel.Clear();
        StopAllCoroutines();
    }
}
