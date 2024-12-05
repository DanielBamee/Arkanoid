using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody rb; // Referencia al Rigidbody de la pelota

    public float bounceForce = 10f; // Fuerza de rebote


    void Start()
    {
        // Obtener el Rigidbody al inicio
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Obtener la normal del impacto para cambiar la dirección de la pelota
        Vector3 normal = collision.contacts[0].normal;

        // Si la colisión fue en el eje X o Z, invertimos la dirección en ese eje
        if (Mathf.Abs(normal.x) > Mathf.Abs(normal.z))
        {
            // Rebotar en el eje X
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            // Rebotar en el eje Z
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -rb.velocity.z);
        }

        // Aplicamos un pequeño ajuste en la velocidad para simular el rebote
        rb.velocity = rb.velocity.normalized * bounceForce;
    }
}
