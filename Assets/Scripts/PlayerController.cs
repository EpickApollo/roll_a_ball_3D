using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 10f;
    private int count;
    private int totalPickUps; // Número total de elementos en el nivel

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();

        // Contar cuántos objetos "PickUp" hay en la escena actual
        totalPickUps = GameObject.FindGameObjectsWithTag("PickUp").Length;

        if (countText != null)
            setCountText();
        else
            Debug.LogWarning("countText no está asignado en el Inspector.");

        if (winTextObject != null)
            winTextObject.SetActive(false);
        else
            Debug.LogWarning("winTextObject no está asignado en el Inspector.");
    }

    void OnMove(InputValue movementVal)
    {
        Vector2 movementVector = movementVal.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText()
    {
        if (countText != null)
        {
            countText.text = $"Puntuación: {count} / {totalPickUps}";

            if (count >= totalPickUps && winTextObject != null)
                winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }
}
