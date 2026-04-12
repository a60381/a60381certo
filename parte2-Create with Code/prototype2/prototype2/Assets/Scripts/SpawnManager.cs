using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    // Passo 3: Novas variáveis para o atraso inicial e intervalo de repetição
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    void Start()
    {
        // Passo 1: Chama a função repetidamente (Nome da função, tempo para começar, intervalo)
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Passo 2: O método Update agora fica vazio ou sem a verificação da tecla S
    void Update()
    {
        // O if (Input.GetKeyDown(KeyCode.S)) foi removido como pedido
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}