using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    void Start()
    {
        // Salva a posição inicial do cenário
        startPos = transform.position;

        // Calcula a metade da largura do BoxCollider para definir o ponto de repetição
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        // Se a posição X atual for menor que a posição inicial menos a largura de repetição
        if (transform.position.x < startPos.x - repeatWidth)
        {
            // Teletransporta o cenário de volta para a posição inicial
            transform.position = startPos;
        }
    }
}