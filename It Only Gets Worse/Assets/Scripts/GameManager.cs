using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private GameObject targetObject;

    [Header("Instantiate Enemy")]
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform enemyParent;

    [Header("Instantiate Boss")]
    [SerializeField] private GameObject bossPrefab;

    [SerializeField] private Transform bossParent;

    [Header("Enemy Settings")]
    [SerializeField] private int enemiesToSpawn;

    [Header("Boss Settings")]
    [SerializeField] private int bossesToSpawn;

    private Entity basicEnemy;
    private Entity bossEnemy;

    private void Awake()
    {
        basicEnemy = (Entity)Resources.Load("Scriptables/BasicEnemy");
        bossEnemy = (Entity)Resources.Load("Scriptables/BossEnemy");
    }

    private void Start()
    {
        SetUpEnemy();
        SpawnEnemies();
        SpawnBosses();
    }

    private void SetUpEnemy()
    {
        enemiesToSpawn = basicEnemy.num;
        bossesToSpawn = bossEnemy.num;
    }

    private void SpawnEnemies()
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

    private void SpawnBosses()
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