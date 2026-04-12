using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; // Arraste o Prefab aqui no Inspector
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;

    private PlayerController playerControllerScript;

    void Start()
    {
        // Encontra o script do jogador para saber se o jogo acabou
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        // Começa a criar obstáculos repetidamente
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        // Só cria um novo obstáculo se o jogo NÃO tiver acabado
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}