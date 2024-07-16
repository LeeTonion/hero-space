using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class enemi_shoot : MonoBehaviour
{
    
    
    public float a = 1f;
    public LayerMask playerlayer;
    public Transform player;
    public Transform gun_enemi;
    public GameObject shoot;
    public Animator animator;
     float attackcooldown =0;
    public float decaycooldown ;
    public float bulletSpeed;
    Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Rigidbody2D rb =GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        

        Collider2D col = Physics2D.OverlapCircle(player.position, a, playerlayer);
        if (col != null)
        {
            
            attackcooldown += Time.deltaTime;
            if (decaycooldown < attackcooldown)
            {
                animator.SetTrigger("shoot");
                attackcooldown = 0;
            }

        }
       


    }
    private void OnDrawGizmosSelected()
    {
        if (gun_enemi == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(gun_enemi.position, a);
    }
    public void enemiattack()
    {
        GameObject bull = Instantiate(shoot, gun_enemi.position, gun_enemi.rotation);
        Vector2 direction = (player.position - transform.position).normalized;
        bull.transform.right = direction;
        Rigidbody2D rb = bull.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
        }
    }

}
    
