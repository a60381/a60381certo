using UnityEngine;

public class RotateCamera : MonoBehaviour
{
   
    // Definir um valor padrão ajuda a testar o código imediatamente
    public float rotationSpeed = 100.0f;

    void Update()
    {
        // Captura a entrada lateral (A/D ou Setas Esquerda/Direita)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Aplica a rotação no eixo Y (Vector3.up)
        // Multiplicamos por Time.deltaTime para que a velocidade seja constante independente do FPS
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}