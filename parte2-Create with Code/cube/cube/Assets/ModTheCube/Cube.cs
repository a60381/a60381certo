using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    [Header("Configurações de Transform")]
    public Vector3 startingPosition = new Vector3(3, 4, 1);
    public float scaleMultiplier = 1.3f;

    [Header("Configurações de Movimento")]
    public Vector3 rotationSpeed = new Vector3(50, 0, 0);

    [Header("Configurações Visuais")]
    public Color cubeColor = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    public bool useRandomColorOnStart = false;

    void Start()
    {
        // 1. Aplica a posição definida no Inspector
        transform.position = startingPosition;

        // 2. Aplica a escala
        transform.localScale = Vector3.one * scaleMultiplier;

        // 3. Gerencia a cor
        if (useRandomColorOnStart)
        {
            // Bônus: Cor aleatória ao iniciar
            Renderer.material.color = new Color(Random.value, Random.value, Random.value, cubeColor.a);
        }
        else
        {
            Renderer.material.color = cubeColor;
        }
    }

    void Update()
    {
        // 4. Rotação controlada por um Vector3 público (X, Y, Z)
        transform.Rotate(rotationSpeed * Time.deltaTime);

        // Extra: Como mudar a cor ao longo do tempo (Efeito de pulsação)
        // Renderer.material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));
    }
}