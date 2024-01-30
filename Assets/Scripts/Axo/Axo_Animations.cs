using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axo_Animations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Axo_Move move;
    private void Update()
    {
        animator.SetBool("Walking", move.walking);
    }

}
