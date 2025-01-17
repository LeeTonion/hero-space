using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    
    // Update is called once per frame
   protected void Update()
    {
        Destroy(gameObject,10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }


}
