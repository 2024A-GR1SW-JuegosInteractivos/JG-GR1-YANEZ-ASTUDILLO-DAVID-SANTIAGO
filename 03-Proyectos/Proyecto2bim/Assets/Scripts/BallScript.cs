using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int totalEnemies;
    private int destroyedEnemies = 0;
    private float delayDestroy = 0.2f;
    void Start()
    {
        
        // Cuenta el total de objetos "trash" al inicio
        totalEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Debug.Log("Destruyendo enemigo...");
            Destroy(other.gameObject, delayDestroy);
            
            destroyedEnemies++;

            if (destroyedEnemies >= totalEnemies)
            {
                // Asegúrate de que el mensaje de victoria esté desactivado al inicio
                Debug.Log("Felicidades ha destruido a todos los enemigos!!!");
            }
            
            // Destruye el objeto actual (this)
            Destroy(this.gameObject);
        }
    }
}
