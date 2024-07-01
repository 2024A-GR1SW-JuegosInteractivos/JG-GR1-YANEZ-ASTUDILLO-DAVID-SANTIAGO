using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarritoScript : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200.0f;

    [SerializeField] float moveSpeed = 15f;

    [SerializeField] private float velocidadRapido = 20f;

    [SerializeField] private float velocidadLento = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 45);
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rapido")
        {
            Debug.Log("Ir rapído");
            moveSpeed = velocidadRapido;
        }
        
        if (other.tag == "Lento")
        {
            Debug.Log("Ir Lente");
            moveSpeed = velocidadLento;
        }
    }
}
