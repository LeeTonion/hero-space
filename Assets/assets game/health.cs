using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;


public class maus : MonoBehaviour
{
    public float maxbood = 100;
    float bood;
    public float maxenergy = 100;
    float electricity;
    public GameObject gameObject;
    public Animator animator;
    public healthbar hea;
    public energybar ene;
    public bool b =false;
    public bool c;
    void Start()
    {
        bood = maxbood;
        electricity = maxenergy;
        ene.maxenergy(electricity);
        hea.setmaxheath(bood);

    }


    public void attack(float damage)
    {
        bood -= damage;
        hea.sethealth(bood);
        if (bood <= 0)
        {
            Die();
        }
    }
    public float energys(int energy)
    {
        electricity -= energy;
        ene.setenergy(electricity);
        return electricity;
    }
    public void addeneergy()
    {
        electricity = maxenergy;
        ene.maxenergy(electricity);
    }
    public void Die()
    {
        animator.SetTrigger("die");

        Destroy(gameObject, 2);
        SceneManager.LoadScene("game over");

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "toxic")
        {
            GetComponent<maus>().attack(0.1f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gun_enemi")
        {
            GetComponent<maus>().attack(1);

        }

    }
}
