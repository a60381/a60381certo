using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15f;
    private PlayerController playerControllerScript;

    void Start()
    {
        // Conecta com o script do jogador para saber se o jogo acabou
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // Se o jogo não acabou, move para a esquerda
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Se o objeto sair do limite da tela e for um obstáculo, ele é destruído
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}