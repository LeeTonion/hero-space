using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class many_enemi : MonoBehaviour
{
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int count = couttag("enemi");
        
        if (count < 5)
        {
            gameObject.SetActive(true);
        }

        else if (count == 5)
        {
            gameObject.SetActive(false);
        }
    }
    int couttag(string tag)
    {
        GameObject[] taggameobject = GameObject.FindGameObjectsWithTag(tag);
        return taggameobject.Length;
    }
}
