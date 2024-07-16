using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charac : MonoBehaviour
{
    public Animator animator;
    public GameObject game;
    public GameObject games;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player")
        {
            game.SetActive(true);
            games.SetActive(false);

            if (game.activeSelf == false)
            {
                animator.SetTrigger("death");
            }
        }
    }
}
