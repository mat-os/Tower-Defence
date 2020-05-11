using DG.Tweening;
using UnityEngine;

public class MoveOnWaypoints : MonoBehaviour
{
    //время, за которое враг пройдет путь
    [SerializeField]private float durationOfPathTravel;

    private Enemy thisEnemy;
    
    #region MonoBehaviour
    private void OnValidate()
    {
        if (durationOfPathTravel < 1)
        {
            durationOfPathTravel = 1;
        }
    }


    #endregion

    void Start()
    {
        thisEnemy = gameObject.GetComponent<Enemy>();
        
        transform.DOPath(WaypointSystem.points, durationOfPathTravel, PathType.Linear, PathMode.TopDown2D)
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
