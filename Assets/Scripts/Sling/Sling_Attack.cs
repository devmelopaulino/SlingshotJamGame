using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Sling_Attack : MonoBehaviour
{
    [SerializeField] private Sling_Inputs inputs;
    [SerializeField] private GameObject[] model_desative;
    [SerializeField] private GameObject[] model_ative;

    [SerializeField] private bool can_attack;

    [SerializeField] private float time_up;
    [SerializeField] private float time_push;
    [SerializeField] private float time_give;
    [SerializeField] private float time_back;
    [SerializeField] private AnimationClip up_animation;
    [SerializeField] private AnimationClip push_animation;
    [SerializeField] private AnimationClip give_animation;
    [SerializeField] private AnimationClip back_animation;

    [SerializeField] public bool uping;
    [SerializeField] public bool pushing;
    [SerializeField] public bool holding;
    [SerializeField] public bool giving;
    [SerializeField] public bool backing;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform aim;

    [SerializeField] private GameObject rock;

    [SerializeField] private Transform rock_locations;

    [SerializeField] private float max_more;
    private void Start()
    {
        time_up = up_animation.length;
        time_push = push_animation.length;
        time_give = give_animation.length;
        time_back = back_animation.length;
    }
    private void Update()
    {
        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        if(can_attack && inputs.left_click_hold) 
        {
            can_attack = false;
            foreach(var model in model_desative) 
            {
                model.SetActive(false);
            }
            foreach (var model in model_ative)
            {
                model.SetActive(true);
            }            
            uping = true;
            yield return new WaitForSeconds(time_up); // UP ^^^
            uping = false;
            pushing = true;
            yield return new WaitForSeconds(time_push); // PUSH ^^^
            pushing = false;

            float more_velocity = 1f;
            while (inputs.left_click_hold)
            {
                holding = true;
                if (more_velocity < max_more)
                {
                    more_velocity += 0.1f;
                }
                yield return null;
            }

            giving = true;

            yield return new WaitForSeconds(time_give); // GIVE ^^^
            giving = false;
            backing = true;

            GameObject new_rock = Instantiate(rock, rock_locations.position, Quaternion.identity);
            Vector3 direction = (aim.transform.position - rock_locations.transform.position).normalized;

            direction *= more_velocity;

            new_rock.GetComponent<Rock_Move>().Move(direction);

            yield return new WaitForSeconds(time_back); // BACK ^^^
            backing = false;
            giving = false;
            uping = false;
            pushing = false;
            holding = false;
            foreach (var model in model_ative)
            {
                model.SetActive(false);
            }
            foreach (var model in model_desative)
            {
                model.SetActive(true);
            }
            can_attack = true;
        }
    }

}
