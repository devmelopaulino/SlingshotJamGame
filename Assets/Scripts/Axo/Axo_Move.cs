using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axo_Move : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    [SerializeField] private Axo_Inputs inputs;
    [SerializeField] private float velocity;
    [SerializeField] private float gravity;
    [SerializeField] public bool walking;
    [SerializeField] public float horizontal_direction;
    private void Update()
    {

        character.Move(transform.TransformDirection(new Vector3(inputs.raw_horizontal_axis,gravity, inputs.raw_vertical_axis).normalized * Time.deltaTime * velocity));
        walking = inputs.raw_vertical_axis > 0 || inputs.raw_vertical_axis < 0 || inputs.raw_horizontal_axis > 0 || inputs.raw_horizontal_axis < 0;
        horizontal_direction = inputs.horizontal_axis;
    }
}
