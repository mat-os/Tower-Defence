using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticCollector : MonoBehaviour
{
    private int killedEnemies;
    public int KilledEnemies => killedEnemies;

    public void AddKillToStatistic()
    {
        killedEnemies++;
    }
}
