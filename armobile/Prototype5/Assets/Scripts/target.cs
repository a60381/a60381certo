using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    // Variáveis para controlar os valores (facilita ajustes no Inspector)
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        // Aplicando as forças e posições usando os métodos personalizados
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Chamado quando o usuário clica no objeto com o mouse
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    // Chamado quando o objeto entra em um trigger (como o sensor de "fim de jogo")
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Método para calcular a força aleatória para cima
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Método para calcular um valor de torque aleatório
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Método para calcular a posição inicial aleatória
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}