using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_animations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Box_Attack attack;
    [SerializeField] private Enemy_Move move;
    [SerializeField] private AnimationClip attackanim;
    [SerializeField] private bool can_wait = true;
    private void Update()
    {
        StartCoroutine(WaitAttack());
        animator.SetBool("Attacking", attack.attacking);
    }
    private IEnumerator WaitAttack()
    {
        if (can_wait && move.arrive)
        {
            can_wait = false;
            attack.attacking = true;
            move.can_move = false;
            yield return new WaitForSeconds(attackanim.length);
            attack.attacking = false;
            move.can_move = true;
            can_wait = true;
        }
    }
}
