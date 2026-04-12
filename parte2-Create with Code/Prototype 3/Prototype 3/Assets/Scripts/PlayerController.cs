using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variáveis de Componentes
    private Rigidbody playerRb;
    private Animator playerAnim;

    // Variáveis de Configuração
    public float jumpForce = 10;
    public float gravityModifier = 2;

    // Variáveis de Estado
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;

    void Start()
    {
        // Inicializa os componentes
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        // Ajusta a gravidade do jogo para o pulo não parecer "lento"
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        // Lógica de Pulo: só pula se apertar Espaço, estiver no chão e o jogo não acabou
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            // Ativa o gatilho da animação de pulo
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    // Detecta colisões com o Chão e Obstáculos
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Se tocar no chão, reseta a permissão de pulo
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            // Se tocar num obstáculo, o jogo termina
            gameOver = true;
            Debug.Log("Game Over!");

            // Ativa animações de morte
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}