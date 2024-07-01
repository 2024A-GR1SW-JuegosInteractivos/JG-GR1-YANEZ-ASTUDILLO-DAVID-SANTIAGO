using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColiderEjemplo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float delayDestroy = 0.5f;
    private bool tienePaquete; //False
    [SerializeField] private Color32 tienePaqueteColor = new Color32(255, 0, 0, 255);
    [SerializeField] private Color32 noTienePaqueteColor = new Color32(0, 0, 255, 255);

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando en trigger!!!");
        
        if (other.tag == "Paquete" && !tienePaquete)
        {
            Debug.Log("Recogio paquete");
            tienePaquete = true;
            spriteRenderer.color = tienePaqueteColor;
            Destroy(other.gameObject, delayDestroy);
        }
        if (other.tag == "Cliente" && tienePaquete)
        {
            tienePaquete = false;
            spriteRenderer.color = noTienePaqueteColor;
            Debug.Log("Dejo paquete");
        }
    }

}
