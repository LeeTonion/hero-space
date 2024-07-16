using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomenergy : MonoBehaviour
{
    public GameObject GameObject;
    public float m_spawmtime;
    public float m_maxenergy;

    void Start()
    {
        m_maxenergy = m_spawmtime;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawmtime -= (Time.deltaTime);
        if (m_spawmtime <= 0)
        {
            Vector2 vector2 = new(Random.Range(-6, 27), Random.Range(-17, 14));
            Instantiate(GameObject, vector2, Quaternion.identity);
            m_spawmtime =m_maxenergy ;
        }
        
    }
}
