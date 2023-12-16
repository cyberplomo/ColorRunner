using UnityEngine;

public class turretmanager : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float attackRadius;
    [SerializeField] private Bullet bulletPrefab;

    private Collider[] _enemies;
    private dead currentEnemy = null;
    void Start()
    {
        InvokeRepeating(nameof(ScanArea),0,fireRate);
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,attackRadius);
    }

    private void ScanArea()
    {
        float distance = 1000;
        _enemies = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider enemy in _enemies)
        {
            if (enemy.gameObject.TryGetComponent(out dead enemyScript))
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (dist<=distance)
                {
                    currentEnemy = enemyScript;
                    distance = dist;
                }
            }
        }

        if (currentEnemy)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.SetTarget(currentEnemy.transform);
        }
    }

    private void Update()
    {
        if (currentEnemy)
        {
            Vector3 dir = currentEnemy.transform.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}