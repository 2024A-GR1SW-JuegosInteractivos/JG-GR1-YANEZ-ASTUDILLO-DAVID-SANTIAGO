using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroScript : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    [SerializeField] float steerSpeed = 200.0f;

    [SerializeField] float moveSpeed = 15f;

    [SerializeField] private float velocidadRapido = 1.0f;

    [SerializeField] private float velocidadLento = 1.0f;
    [SerializeField] private float delayDestroy = 0.2f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, -moveAmount, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            Debug.Log("Llegó el jugador!!!");
        }
        
        if (other.tag == "powerup")
        {
            Debug.Log("Comiste un powerup +"+ velocidadRapido +" de velocidad");
            Destroy(other.gameObject, delayDestroy);
            moveSpeed += velocidadRapido;
        }
        
        if (other.tag == "powerdown")
        {
            Debug.Log("Comiste un powerup -"+ velocidadLento +" de velocidad");
            Destroy(other.gameObject, delayDestroy);
            moveSpeed -= velocidadLento;
        }
    }
}
