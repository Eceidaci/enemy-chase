using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Collector : MonoBehaviour
{
    [SerializeField] GameObject died;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {     
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);  
            
        } 
        
    }
    


}
