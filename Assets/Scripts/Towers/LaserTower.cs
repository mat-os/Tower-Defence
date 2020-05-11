using UnityEngine;

public class LaserTower : Tower
{
    [Header("Visual Settings")]
    [SerializeField]private LaserTowerEffects laserTowerEffects;

    private Enemy targetEnemy;
    
    private float fireCountdown;
    
    void Start()
    {
        InvokeRepeating("FindTarget",0.0f,0.5f);
    }

    //Проверяем, есть ли у нас враг; Проверяем, готовы ли сделать выстрел; Если всё готово- стреляем.
    void Update()
    {
        if(targetEnemy == null)
            return;
        
        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / AttackRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    
    //Поиск целей- выполняется через обращение к списку всех противников на уровне - "SpawnEnemiesSystem.enemiesOnLevel"
    //Далее выбирается ближайщий к башне противник
    void FindTarget()
    {
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
        
        foreach (var enemy in SpawnEnemiesSystem.enemiesOnLevel)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= AttackRange)
        {
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            targetEnemy = null;
        }
    }
    
    //Выстрел по врагу- запускаем визуальные эффекты и наносим урон врагу
    void Shoot()
    {
        AttackEffects(targetEnemy);
        
        targetEnemy.ApplyDamage(Damage);
    }

    
    private void AttackEffects(Enemy target)
    {
        //Визуальные фишки
        laserTowerEffects.DrawLaserLine(targetEnemy);
        laserTowerEffects.LookAtTarget(targetEnemy);
    }

    #region Editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
    #endregion
}




//Вариант поиска целей через OverlapCircle если у врагов есть коллайдер
/*void FindTarget()
{
    var targets = Physics2D.OverlapCircle(transform.position, AttackRange, LayerMask.GetMask("Enemy"));

    if (targets == null) return;
    
    enemyToAttack = targets.GetComponent<Enemy>();
}*/