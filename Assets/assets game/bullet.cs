using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    
  
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemi")
        {
            
            Destroy(this.gameObject);
        }
    }
   
}
