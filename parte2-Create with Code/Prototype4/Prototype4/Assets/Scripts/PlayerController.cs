using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;

    [Header("Configurações de Movimento")]
    public float speed = 10.0f;

    // 🔵 INDICADOR DO POWERUP
    public GameObject powerupIndicator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Faz o indicador seguir o jogador
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward * speed * forwardInput);
        playerRb.AddForce(Vector3.right * speed * sideInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            // Ativa o indicador visual
            powerupIndicator.gameObject.SetActive(true);

            // Inicia o tempo do powerup
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);

        hasPowerup = false;

        // Desativa o indicador visual
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            Debug.Log("Player collided with " + collision.gameObject.name +
                      " with powerup set to " + hasPowerup);

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}