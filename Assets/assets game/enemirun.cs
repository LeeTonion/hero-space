using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemirun : MonoBehaviour
{
    public Transform player;
    public float range;
    public float speed;
    private Rigidbody2D rb;
    public Animator animator;
    public float b;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float b = Vector2.Distance(gameObject.transform.position, player.position);
        if (b > range )
        {
             transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            animator.SetBool("run",true);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gun" )
        {
            animator.SetTrigger("die");
            this.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject,1.5f);
        }
    }
  
}
