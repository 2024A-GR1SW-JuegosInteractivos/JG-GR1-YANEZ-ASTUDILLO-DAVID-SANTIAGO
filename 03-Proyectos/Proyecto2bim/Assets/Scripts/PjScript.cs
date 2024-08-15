using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] float steerSpeed = 100.0f;
    [SerializeField] float moveSpeed = 1f;
    
    public Transform shootPoint;   // Punto desde donde se disparará la "ball"
    public float ballSpeed = 10f;  // Velocidad de la "ball"

    // Prefabs para los diferentes tipos de ball
    public GameObject baseballPrefab;
    public GameObject fireBallPrefab;
    public GameObject iceBallPrefab;
    public GameObject electricBallPrefab;

    private Rigidbody2D rb;
    private GameObject currentBallPrefab;  // Prefab actual que se usará para la ball

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        currentBallPrefab = baseballPrefab; // Prefab por defecto
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
        
        // Cambio de prefab según la tecla presionada
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBallPrefab = baseballPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBallPrefab = fireBallPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentBallPrefab = iceBallPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentBallPrefab = electricBallPrefab;
        }

        // Disparo
        if (Input.GetMouseButtonDown(0))  // Detecta el clic del mouse
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        // Crear la "ball" en la posición del punto de disparo usando el prefab actual
        GameObject ball = Instantiate(currentBallPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

        // La dirección de disparo se basa en la rotación actual del personaje
        Vector2 shootDirection = transform.up;  // `transform.up` apunta en la dirección a la que está mirando el personaje

        // Asignar la velocidad y dirección a la "ball"
        ballRb.velocity = shootDirection * ballSpeed;
        
        // Destruir la "ball" después de 2 segundos
        Destroy(ball, 2f);
    }
}
