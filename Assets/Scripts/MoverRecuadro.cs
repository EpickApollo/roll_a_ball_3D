using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRecuadro : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
   // public float velocidad = 3f; // Velocidad de movimiento
    private int direccion = 1; // Dirección inicial

    void Update()
    {
        // Mover el objeto de izquierda a derecha
        transform.Translate(Vector3.right * velocidad * Time.deltaTime * direccion);

        // Invertir dirección cuando llegue a ciertos límites
        if (transform.position.x > 5)
        {
            direccion = -1; // Moverse hacia la izquierda
        }
        else if (transform.position.x < -5)
        {
            direccion = 1; // Moverse hacia la derecha
        }
    }
}
