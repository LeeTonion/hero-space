using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;

using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;
    private Vector3 move;
    private Rigidbody2D rb;
    public Animator animator;
    public GameObject bulletprefab;
    public GameObject fireposition;
    public bool b = true;
    private bool c = false;
    private float d=0;
    public TextMeshProUGUI TextMeshPro1;
    
    bool isDashing = false;
    private float dashtime;
    public float _dashtime;
    public float dashspeed;
    private static bool gun = false;
    private static bool dash = false;
   
    void Start()
    {
         
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        TextMeshPro1.SetText(d.ToString());                                     
      
    }
    void Update()
    {
        float a = Input.GetAxis("Horizontal");
        move.x= Mathf.Abs(a);
        move.y = Input.GetAxis("Vertical");
        transform.Translate(move * Speed * Time.deltaTime);
        
        if (move.x != 0 || move.y != 0)
        {
            animator.SetBool("run", true);


            if (a < 0 && b)
            {

                transform. Rotate(0, 180, 0);
                b = !b;
            }
            if (a > 0 && !b)
            {
                transform.Rotate(0, 180, 0);
                b = !b;
            }
        }
        else
        {
            animator.SetBool("run", false);
        }
             if (Input.GetKeyDown(KeyCode.Space) && gun)
             {
                if (GetComponent<maus>().energys(1) > 0)
                {
                    animator.SetTrigger("shoot");
                    attack();
                }
                else if (GetComponent<maus>().energys(1) <= 0)
                {
                    animator.SetTrigger("shoot");
                }
             }
            if (Input.GetKeyDown(KeyCode.R) && c)
            {
            GetComponent<maus>().addeneergy();
            d--;
            TextMeshPro1.SetText(d.ToString());
            if (d==0)
            {
                c= false;
            }
        }
           
        if (Input.GetKeyDown (KeyCode.Q) && dashtime <=0 && isDashing ==false && dash  )
        {
           
            if (GetComponent<maus>().energys(4) > 4)
            { 
            GetComponent<maus>().energys(4);
            Speed += dashspeed;
            dashtime = _dashtime;
            isDashing = true;
            }
            
        }
        if (dashtime <= 0 && isDashing)
        {
            Speed -= dashspeed;
            isDashing=false;
        }
        else { dashtime -= Time.deltaTime;}
        }
        public void attack( )
        {
            GameObject bullet = Instantiate(bulletprefab, fireposition.transform.position, fireposition.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(fireposition.transform.right * 1000);

        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "qwe") { gun = true;Destroy(collision.gameObject); }
        if(collision.tag == "dash") { dash = true; Destroy(collision.gameObject); }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       if (collision.tag == "energy")
        {
            c= true;
            Destroy(collision.gameObject);
            d++;
            TextMeshPro1.SetText(d.ToString());
        }
    }
}




