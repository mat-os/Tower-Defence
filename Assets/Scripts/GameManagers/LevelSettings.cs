using System;
using System.IO;
using UnityEngine;


public class LevelSettings : MonoBehaviour 
{
    [SerializeField]private LevelData levelData = new LevelData();
    public LevelData LevelData => levelData;

    [ContextMenu("Save")]
    public void Save()
    {
    string json = JsonUtility.ToJson(levelData);
        
    File.WriteAllText(GetFilePath(), json);
    
    Debug.Log("Level Data Generating on this path: " + GetFilePath());
    }

    [ContextMenu("Load")]
    public void Load()
    {
            if(!File.Exists(GetFilePath())) {return; }

            string json = File.ReadAllText(GetFilePath());

            levelData = JsonUtility.FromJson<LevelData>(json);
            
            Debug.Log("Level Data was loaded");

    }

    private string GetFilePath()
    {
        return $"{Application.dataPath}/Resources/LevelSettings.txt";
    }
}

[Serializable]
public class LevelData
{
    [Tooltip("Время между волнами противников")]
    [SerializeField] private float timeBetweenWaves;
    public float TimeBetweenWaves => timeBetweenWaves;

    [Tooltip("Максимальное добавночное увеличение кол-ва противников в волне")]
    [SerializeField] private int maxRandomEnemiesInWave;
    public int MaxRandomEnemiesInWave => maxRandomEnemiesInWave;
}
