using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class upshoot : MonoBehaviour
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
            }
        
        }
    
        public void enemi()
        {
        Vector2 randompos = Random.insideUnitCircle * b;
        Vector3 swanp = new Vector3(randompos.x,0f,randompos.y)+ transform.position;
        Instantiate(abc,swanp,Quaternion.identity);
        }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,b);
    }
} 
