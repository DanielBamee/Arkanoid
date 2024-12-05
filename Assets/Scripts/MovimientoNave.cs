using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento de la nave
    public float xMin = -8f; // Límite mínimo del eje X (izquierda)
    public float xMax = 8f;  // Límite máximo del eje X (derecha)

    private float inputX; // Entrada horizontal

    void Update()
    {
        // Obtener la entrada de las teclas A (izquierda) y D (derecha)
        inputX = Input.GetAxis("Horizontal");

        // Mover la nave en el eje X
        Vector3 newPosition = transform.position + new Vector3(inputX, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Limitar la posición para que no salga de la pantalla
        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);

        // Aplicar la nueva posición
        transform.position = newPosition;
    }
}