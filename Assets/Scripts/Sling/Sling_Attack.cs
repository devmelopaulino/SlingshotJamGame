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
        CalculatePath();
    }
    private void CalculatePath()
    {
        //RectTransformUtility.ScreenPointToWorldPointInRectangle(aim_canvas, aim_canvas.position, Camera.main, out Vector3 path);
        //Debug.Log(path);

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
            //yield return new WaitForSeconds(0.1f);

            uping = true;
            yield return new WaitForSeconds(time_up); // UP ^^^

            uping = false;
            pushing = true;

            yield return new WaitForSeconds(time_push); // PUSH ^^^


            while (inputs.left_click_hold)
            {
                pushing = false;
                holding = true;
                yield return null;
            }

            giving = true;

            yield return new WaitForSeconds(time_give); // GIVE ^^^

            giving = false;
            backing = true;
            GameObject new_rock = Instantiate(rock, rock_locations.position, Quaternion.identity);

            //Vector3 centroDaTela = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            //Vector3 centroDoMundo = Camera.main.ScreenToWorldPoint(centroDaTela);
            //Vector3 direcao = (centroDoMundo - rock_locations.transform.position).normalized;

            //direcao.y = direcao.y * 4f;

            //RectTransformUtility.ScreenPointToWorldPointInRectangle(aim_canvas, aim_canvas.position, Camera.main, out Vector3 path);
            Vector3 direction = (Camera.main.transform.position - rock_locations.transform.position).normalized;

            //direction = Camera.main.transform.position;




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
