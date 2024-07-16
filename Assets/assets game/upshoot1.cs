using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upshoot1 : MonoBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public GameObject abc;
    public float spawntime;
    public float m_spawmtime;


    public float b = 0;
    void Start()
    {
        m_spawmtime = 0;

    }
    void Update()
    {
        m_spawmtime -= (Time.deltaTime);
        if (m_spawmtime <= 0)
        {
            enemi();
            m_spawmtime = spawntime;
            bool a = abc.activeSelf;
            if (!a)
            {
                Destroy(abc);
            }
        }
    }

    public void enemi()
    {
        Vector2 swanp = new(Random.Range(-6f, 27f), Random.Range(-17f, 14f));
        Instantiate(abc, swanp, Quaternion.identity);
    }
    
}
