using DG.Tweening;
using UnityEngine;

public class MoveOnWaypoints : MonoBehaviour
{
    private Enemy thisEnemy;
    
    void Start()
    {
        thisEnemy = gameObject.GetComponent<Enemy>();
        
        //Движение врага задается через DOTWeen. 
        transform.DOPath(WaypointSystem.points, thisEnemy.DurationOfPathTravel, PathType.Linear, PathMode.TopDown2D)
            .SetEase(Ease.Linear)
            .SetLookAt(lookAhead: 0)
            .OnComplete(OnPathComplete);
    }

    //Когда враг доехал до базы
    private void OnPathComplete()
    {
        thisEnemy.DealDamage();
        SpawnEnemiesSystem.enemiesOnLevel.Remove(this.gameObject);
    }
}
