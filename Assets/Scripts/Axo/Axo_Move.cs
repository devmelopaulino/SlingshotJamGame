using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axo_Move : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private Axo_Inputs inputs;
    [SerializeField] private float velocity;
    [SerializeField] private Transform[] body_to_rote;
    [SerializeField] public bool walking;
    [SerializeField] public float horizontal_direction;
    private void Update()
    {
        Vector3 direction = transform.TransformDirection(inputs.raw_horizontal_axis, 0,inputs.raw_vertical_axis).normalized;
        body.velocity = Time.deltaTime * velocity * direction;
        walking = body.velocity.sqrMagnitude > 0;
        horizontal_direction = inputs.horizontal_axis;
    }
}
