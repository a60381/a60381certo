using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // contador de inimigos
    public int enemyCount;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        if (player == null)
        {
            Debug.LogError("Player não encontrado!");
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.linearVelocity = lookDirection * speed;
        }
    }

    void Update()
    {
        // conta quantos inimigos existem
        enemyCount = FindObjectsByType<EnemyFollow>(FindObjectsSortMode.None).Length;

        // se não houver inimigos, spawn nova wave
        if (enemyCount == 0)
        {
            SpawnEnemyWave(1);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // aqui você coloca sua lógica de spawn
        Debug.Log("Spawnando nova wave: " + enemiesToSpawn);
    }
}