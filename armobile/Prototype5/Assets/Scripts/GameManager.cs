using UnityEngine;
using TMPro; // Necessário para usar o TextMeshPro
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    // Variáveis da pontuação
    private int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        StartCoroutine(SpawnTarget());

        // Inicializa a pontuação
        score = 0;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}