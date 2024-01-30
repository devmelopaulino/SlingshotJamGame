using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling_Attack : MonoBehaviour
{
    [SerializeField] private Sling_Inputs inputs;
    [SerializeField] private GameObject model_desative;

    [SerializeField] private bool can_attack;

    [SerializeField] private float time_up;
    [SerializeField] private AnimationClip up_animation;

    [SerializeField] public bool uping;
    private void Start()
    {
        time_up = up_animation.length;
    }
    private void Update()
    {
        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        if(can_attack) 
        {
            can_attack = false;
            model_desative.SetActive(false);
            uping = true;

            yield return new WaitForSeconds(time_up);
            uping = false;

            yield return null;
            model_desative.SetActive(true);
            can_attack = true;
        }
    }

}
