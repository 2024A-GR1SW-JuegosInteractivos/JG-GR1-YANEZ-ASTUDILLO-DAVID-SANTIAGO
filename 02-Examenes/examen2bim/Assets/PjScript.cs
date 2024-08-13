using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjScript : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    [SerializeField] float steerSpeed = 100.0f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] private float delayDestroy = 0.2f;

    private int totalTrashObjects;
    private int destroyedTrashObjects = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Cuenta el total de objetos "trash" al inicio
        totalTrashObjects = GameObject.FindGameObjectsWithTag("trash").Length;
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "trash")
        {
            Debug.Log("Recogiendo basura...");
            Destroy(other.gameObject, delayDestroy);
            
            // Incrementa el contador de basura destruida
            destroyedTrashObjects++;

            // Verifica si se han destruido todos los objetos "trash"
            if (destroyedTrashObjects >= totalTrashObjects)
            {
                // Asegúrate de que el mensaje de victoria esté desactivado al inicio
                Debug.Log("Felicidades ha limpiado todo el parque!!!");
            }
        }
    }
}
