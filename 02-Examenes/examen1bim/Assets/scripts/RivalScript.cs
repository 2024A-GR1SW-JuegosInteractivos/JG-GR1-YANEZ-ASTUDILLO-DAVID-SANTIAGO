using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

    [SerializeField] private float choque_nerf = 1.0f;
    
    [SerializeField] private float velocidadRapido = 1.5f;
    [SerializeField] private float delayDestroy = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = moveSpeed * Time.deltaTime;
        transform.Translate(0, -moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            Debug.Log("Llegó el rival!!!");
        }

        if (other.tag == "Player")
        {
            Debug.Log("Choque!!! -" + choque_nerf + " de velocidad");
            moveSpeed -= choque_nerf;
        }
        
        if (other.tag == "powerup")
        {
            Debug.Log("Rival come un powerup +"+ velocidadRapido +" de velocidad");
            Destroy(other.gameObject, delayDestroy);
            moveSpeed += velocidadRapido;;
        }
    }
}
