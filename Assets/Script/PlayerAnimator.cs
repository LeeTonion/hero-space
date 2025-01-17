using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string RUN = "run";
    private const string SHOOT = "shoot";
    private const string DASH = "run";
    [SerializeField] private Player Player;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool(RUN, Player.IsWalking());
        animator.SetBool(SHOOT,Player.IsShoot());
        if (Player.IsDie()) 
        {
            animator.SetTrigger("die");
        }
        
    }

}
