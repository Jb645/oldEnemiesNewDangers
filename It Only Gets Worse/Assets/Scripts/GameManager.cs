using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] GameObject targetObject;

    [Header("Instantiate Enemy")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyParent;

    [Header("Instantiate Boss")]
    [SerializeField] GameObject bossPrefab;
    [SerializeField] Transform bossParent;

    [Header("Enemy Settings")]
    [SerializeField] int enemiesToSpawn;

    [Header("Boss Settings")]
    [SerializeField] int bossesToSpawn;

    private void Start()
    {
        SpawnEnemies();
        SpawnBosses();
    }

    void SpawnEnemies()
    {
        //spawn enemies
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            enemyPrefab.transform.position = new Vector3(Random.Range(0f, 100f), 0f, Random.Range(0f, 100f));
            GameObject newEnemy = Instantiate(enemyPrefab, enemyParent);

            EnemyController enemyController = newEnemy.GetComponent<EnemyController>();
            enemyController.playerToChase = targetObject.transform;
        }
    }

    void SpawnBosses()
    {
        //spawn boss
        for (int i = 0; i < bossesToSpawn; i++)
        {
            bossPrefab.transform.position = new Vector3(Random.Range(0f, 100f), 0f, Random.Range(0f, 100f));
            GameObject newBoss = Instantiate(bossPrefab, bossParent);

            BossController bossController = newBoss.GetComponent<BossController>();
            bossController.playerToChase = targetObject.transform;
        }
    }
}
