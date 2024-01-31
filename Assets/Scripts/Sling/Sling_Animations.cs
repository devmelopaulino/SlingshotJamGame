using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling_Animations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Sling_Attack sling_attack;

    void Update()
    {
        animator.SetBool("Uping", sling_attack.uping);
        animator.SetBool("Pushing", sling_attack.pushing);
        animator.SetBool("Holding", sling_attack.holding);
        animator.SetBool("Giving", sling_attack.giving);
        animator.SetBool("Backing", sling_attack.backing);
    }
    private void OnEnable()
    {
        animator.SetBool("Uping", false);
        animator.SetBool("Pushing", false);
        animator.SetBool("Holding", false);
        animator.SetBool("Giving", false);
        animator.SetBool("Backing", false);
    }
}
