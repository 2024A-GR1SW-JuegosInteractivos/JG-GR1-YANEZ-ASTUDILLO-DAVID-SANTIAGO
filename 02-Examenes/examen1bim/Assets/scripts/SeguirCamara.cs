using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject cosaQueQuieroSeguir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.position = cosaQueQuieroSeguir.transform.position + new Vector3(x: 0, y: 0, z: -10);
    }
    
    
}
